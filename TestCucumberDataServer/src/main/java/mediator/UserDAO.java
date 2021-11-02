package mediator;

import db.DataMapper;
import db.DatabaseHelper;
import model.User;
import java.sql.ResultSet;
import java.sql.SQLException;

public class UserDAO
{
	private DatabaseHelper<User> helper;

	public UserDAO() {
		helper = new DatabaseHelper<>("jdbc:postgresql://localhost:5432/postgres?currentSchema=stincubator", "postgres", "mypassword");
	}

	public User create(String username, String password)  {
		helper.executeUpdate("INSERT INTO Users VALUES (?, ?)", username, password);
		return new User(username, password);
	}
	
	private static class UserMapper implements DataMapper<User>
	{
		public User create(ResultSet rs) throws SQLException {
			String username = rs.getString("username");
			String password = rs.getString("password");
			return new User(username, password);
		}
	}
	
	public User[] readAll() {
		return helper.map(new UserMapper(), "SELECT * FROM Users").toArray(new User[0]);
	}

	public User readOne(String username) {
		return helper.mapSingle(new UserMapper(), "SELECT * FROM Users WHERE username = ?", username);
	}
	
	public void delete(String username) {
		helper.executeUpdate("DELETE FROM Users WHERE username = ?", username);
	}
}
