package shop.baseClasses;

import java.security.InvalidParameterException;

import shop.AgeRestriction;

public abstract class ElectronicsProduct extends Product {

	private int guaranteePeriod;
	
	public ElectronicsProduct(String name, double price,
			int quantiyRestriction, AgeRestriction ageRestriction) {
		super(name, price, quantiyRestriction, ageRestriction);
		
	}
	public int getGuaranteePeriod() {
		return guaranteePeriod;
	}
	protected void setGuaranteePeriod(int guaranteePeriod) {
		if (guaranteePeriod < 0) {
			throw new InvalidParameterException("Guarantee Cant Be negative value.");
		}
		this.guaranteePeriod = guaranteePeriod;
	}

}
