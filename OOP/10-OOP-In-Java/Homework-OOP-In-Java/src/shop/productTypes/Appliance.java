package shop.productTypes;

import java.text.ParseException;

import shop.AgeRestriction;
import shop.baseClasses.ElectronicsProduct;

public class Appliance extends ElectronicsProduct{

	public Appliance(String name, double price, int quantiyRestriction,
			AgeRestriction ageRestriction) {
		super(name, price, quantiyRestriction, ageRestriction);
		this.setGuaranteePeriod(6);
	}

	@Override
	public double getPrice() throws ParseException {
		double currentPrice = this.getProductPrice();
		int currentCuantity = this.getQuantity();
		if (currentCuantity < 50) {
			currentPrice = (currentPrice/100)*105;
		}
		return currentPrice;
	}
}
