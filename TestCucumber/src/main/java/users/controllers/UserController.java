package users.controllers;

import java.util.List;
import java.util.stream.Collectors;

import org.springframework.hateoas.CollectionModel;
import org.springframework.hateoas.EntityModel;
import org.springframework.hateoas.IanaLinkRelations;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import users.model.User;
import users.model.UserModelAssembler;
import users.model.InvalidPasswordException;
import users.model.UserNotFoundException;
import users.db.UserRepository;

import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.linkTo;
import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.methodOn;

@RestController public class UserController
{

  private final UserRepository repository;

  private final UserModelAssembler assembler;

  UserController(UserRepository repository, UserModelAssembler assembler)
  {

    this.repository = repository;
    this.assembler = assembler;
  }

  // Aggregate root
  // tag::get-aggregate-root[]
  @GetMapping("/users") public CollectionModel<EntityModel<User>> all()
  {
    List<EntityModel<User>> users = repository.findAll().stream() //
        .map(assembler::toModel) //
        .collect(Collectors.toList());


    return CollectionModel.of(users,
        linkTo(methodOn(UserController.class).all())
            .withSelfRel());
  }
  // end::get-aggregate-root[]

  @PostMapping("/users") ResponseEntity<?> newUser(@RequestBody User newUser)
  {

    EntityModel<User> entityModel = assembler.toModel(repository.save(newUser));

    return ResponseEntity //
        .created(entityModel.getRequiredLink(IanaLinkRelations.SELF).toUri()) //
        .body(entityModel);
  }

  // Single item
  @GetMapping("/users/{username}") @ResponseStatus(HttpStatus.OK) public EntityModel<User> one(
      @PathVariable String username, @RequestParam(value = "password", required = false) String password)
  {
    User user = repository.findById(username) //
        .orElseThrow(() -> new UserNotFoundException(username));

    if(password!=null&&!user.getPassword().equals(password))
    {
      System.out.println("Fail (password)=> "+username);
      throw new InvalidPasswordException();
    }
    System.out.println("Success=> " + user.toString());
    return assembler.toModel(user);
  }

  @PutMapping("/users/{id}") ResponseEntity<?> replaceUser(
      @RequestBody User newUser, @PathVariable String id)
  {

    User updatedUser = repository.findById(id) //
        .map(user -> {
          user.setUsername(newUser.getUsername());
          user.setPassword(newUser.getPassword());
          return repository.save(user);
        }) //
        .orElseGet(() -> {
          newUser.setUsername(id);
          return repository.save(newUser);
        });

    EntityModel<User> entityModel = assembler.toModel(updatedUser);

    return ResponseEntity //
        .created(entityModel.getRequiredLink(IanaLinkRelations.SELF).toUri()) //
        .body(entityModel);
  }

  @DeleteMapping("/users/{id}") ResponseEntity<?> deleteUser(
      @PathVariable String id)
  {

    repository.deleteById(id);

    return ResponseEntity.noContent().build();
  }
}

