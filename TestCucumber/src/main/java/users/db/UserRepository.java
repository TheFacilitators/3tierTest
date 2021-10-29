package users.db;

import org.springframework.data.jpa.repository.JpaRepository;
import users.model.User;

public interface UserRepository extends JpaRepository<User, String>
{

}
