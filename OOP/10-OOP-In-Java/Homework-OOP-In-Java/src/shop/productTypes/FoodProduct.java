package shop.productTypes;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.TimeUnit;

import shop.AgeRestriction;
import shop.baseClasses.Product;
import shop.interfaces.Expirable;
import shop.utils.utils;

public class FoodProduct extends Product implements Expirable {
	
	private String expireDate; 
	
	public FoodProduct(String name, double price,
			int quantiyRestriction, AgeRestriction ageRestriction
			, String expireDate) {
		super(name, price, quantiyRestriction, ageRestriction);
		this.setExpireDate(expireDate);
	}



	public String getExpireDate() {
		return expireDate;
	}



	public void setExpireDate(String expireDate) {
		this.expireDate = expireDate;
	}



	@Override
	public double getPrice() throws ParseException {
		Date now = new Date();
		long diff = utils.getDateDiff(now,this.getExpirationDate(),TimeUnit.DAYS);		
		double currentPrice = this.getProductPrice();		
		if (diff < 15) {
			currentPrice = (currentPrice/100) * 70;
		}	
		
		return currentPrice;
	}


	@Override
	public Date getExpirationDate() throws ParseException {
		 String target = getExpireDate();
         DateFormat df = new SimpleDateFormat("d M y");
         Date result =  df.parse(target);
         return result;
	}
}
