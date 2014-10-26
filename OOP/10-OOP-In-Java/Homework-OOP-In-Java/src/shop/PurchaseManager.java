package shop;

import java.text.ParseException;
import java.util.Date;
import java.util.concurrent.TimeUnit;

import shop.baseClasses.Customer;
import shop.baseClasses.Product;
import shop.interfaces.Expirable;
import shop.utils.ProductException;
import shop.utils.utils;

public class PurchaseManager {

	protected static void ProcessPurchase(Customer customer, Product product) throws ParseException, ProductException {
		if (product.getQuantity() < 1) {
			throw new ProductException("Product is Out of Stock!");						
		}
		if (product instanceof Expirable) {
			Date dateNow = new Date();
			long diff = utils.getDateDiff(dateNow,((Expirable) product).getExpirationDate(),TimeUnit.DAYS);			
			if (diff < 1) {						
				throw new ProductException("Product is out of Date!");
			}
		}
		if ((customer.getBallance() - product.getPrice()) < 0){
			throw new ProductException("Costumer " + customer.getName() + " don't have enought cash!");
		}
		if (IsNotPermited(customer, product)) {
			throw new ProductException("Costumer " + customer.getName() + " is restricted by age to buy this product!");
		}
	}
	protected static boolean IsNotPermited(Customer customer, Product product){
		boolean isNotPermited = false;
			if (product.getAgeRestriction() == AgeRestriction.NONE) {
				isNotPermited = false;
			} else if ((customer.getAge() < 18) && (product.getAgeRestriction() == AgeRestriction.TEENAGER)){
				isNotPermited = true;
			} else if ((customer.getAge() > 18) && (product.getAgeRestriction() == AgeRestriction.ADULT)){
				isNotPermited = true;
			}
		return isNotPermited;
	}  
}
