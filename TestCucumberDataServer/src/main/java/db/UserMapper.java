package db;

import java.sql.ResultSet;
import java.sql.SQLException;

public interface UserMapper<T> {
	T create(ResultSet rs) throws SQLException;
}
