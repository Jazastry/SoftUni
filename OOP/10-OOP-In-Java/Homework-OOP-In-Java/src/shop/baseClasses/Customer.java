package shop.baseClasses;

import java.security.InvalidParameterException;

public class Customer {

	private String name;
	private int age;
	private double ballance;

	public Customer(String name, int age, double ballance) {
		super();
		this.name = name;
		this.age = age;
		this.ballance = ballance;
	}
	
	public String getName() {
		return name;
	}

	public void setName(String name) {
		if (name.equals(null)) {
			throw new InvalidParameterException("Costumer Name can not be null.");
		}
		this.name = name;
	}

	public int getAge() {
		return age;
	}

	public void setAge(int age) {
		if (age < 1) {
			throw new InvalidParameterException("Costumer age can not be negative value or zero.");
		}
		this.age = age;
	}

	public double getBallance() {
		return ballance;
	}

	public void setBallance(double ballance) {
		this.ballance = ballance;
	}	
}
