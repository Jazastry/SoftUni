package shop.productTypes;

import java.text.ParseException;

import shop.AgeRestriction;
import shop.baseClasses.ElectronicsProduct;

public class Computer extends ElectronicsProduct {

	public Computer(String name, double price, int quantiyRestriction,
			AgeRestriction ageRestriction) {
		super(name, price, quantiyRestriction, ageRestriction);
		this.setGuaranteePeriod(24);
	}

	@Override
	public double getPrice() throws ParseException {
		double currentPrice = this.getProductPrice();
		int currentCuantity = this.getQuantity();
		if (currentCuantity > 1000) {
			currentPrice = (currentPrice/100)*95;
		}
		return currentPrice;
	}

}
