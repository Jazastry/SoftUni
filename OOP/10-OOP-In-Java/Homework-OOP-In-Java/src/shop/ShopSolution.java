package shop;

import shop.baseClasses.Customer;
import shop.productTypes.FoodProduct;

public class ShopSolution {

	public static void main(String[] args) throws java.text.ParseException {
		try {
			FoodProduct cigars = new FoodProduct("cigars Victory", 2.50, 5, AgeRestriction.TEENAGER, "22 11 2014");
			
			Customer pecata = new Customer("Pecata", 17, 30.00);
			PurchaseManager.ProcessPurchase(pecata, cigars);
			Customer gopeto = new Customer("Gopeto", 18, 0.44);
			PurchaseManager.ProcessPurchase(gopeto, cigars);
		}
		catch (Exception e) {
			System.out.println(e);
		}
	}
}
