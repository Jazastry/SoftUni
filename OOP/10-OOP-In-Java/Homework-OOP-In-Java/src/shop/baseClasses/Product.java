package shop.baseClasses;

import shop.AgeRestriction;
import shop.interfaces.Buyable;

public abstract class Product implements Buyable {
	
	private String name;
	private double productPrice;
	private int quantity;
	private AgeRestriction ageRestriction;
	
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public double getProductPrice() {
		return productPrice;
	}

	public void setProductPrice(double productPrice) {
		this.productPrice = productPrice;
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantityRestriction) {
		this.quantity = quantityRestriction;
	}

	public AgeRestriction getAgeRestriction() {
		return ageRestriction;
	}

	public void setAgeRestriction(AgeRestriction ageRestriction) {
		this.ageRestriction = ageRestriction;
	}

	public Product(String name, double price, int quantiy, AgeRestriction ageRestriction) {
		this.setName(name);
		this.setProductPrice(price);
		this.setQuantity(quantiy);
		this.setAgeRestriction(ageRestriction);
	}

}
 