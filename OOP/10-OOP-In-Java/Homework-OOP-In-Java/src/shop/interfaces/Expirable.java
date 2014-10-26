package shop.interfaces;

import java.text.ParseException;
import java.util.Date;

public interface Expirable {
	Date getExpirationDate() throws ParseException;
}
