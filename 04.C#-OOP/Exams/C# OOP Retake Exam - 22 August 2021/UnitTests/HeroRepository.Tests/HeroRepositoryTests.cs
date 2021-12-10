using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
	private HeroRepository hr;
	private Hero hero;

	[SetUp]
	public void Setup()
	{
		this.hr = new HeroRepository();
		this.hero = new Hero("Pesho", 50);

		this.hr.Create(hero);
	}

	[Test]
	public void CreateMethodShouldThrowExceptionWhenHeroIsNull()
    {
		Assert.Throws<ArgumentNullException>(() => this.hr.Create(null));
    }

	[Test]
	public void CreateMethodShouldThrowExceptionWhenHeroAlreadyExists()
    {
		Assert.Throws<InvalidOperationException>(() => this.hr.Create(hero));
    }

	[Test]
	public void CreateMethodShouldAddHeroesCorrectly()
    {
		var newHero = new Hero("Lelq ti Goshka", 70);

		this.hr.Create(newHero);

		Assert.AreEqual(2, this.hr.Heroes.Count);
		Assert.True(this.hr.Heroes.FirstOrDefault(h => h.Name == "Lelq ti Goshka") != null);
    }

	[Test]
	public void CreateMethodShouldReturnMessageCorrectly()
    {
		var newHero = new Hero("Lelq ti Goshka", 70);

		var result = this.hr.Create(newHero);

		Assert.AreEqual("Successfully added hero Lelq ti Goshka with level 70", result);
	}

	[Test]
	[TestCase(null)]
	[TestCase(" ")]
	public void RemoveMethodShouldThrowExceptionWhenArgumentsAreNullOrWhiteSpace(string name)
    {
		Assert.Throws<ArgumentNullException>(() => this.hr.Remove(name));
    }

	[Test]
	public void RemoveMethodShouldRemoveHeroesCorrectly()
    {
		var result = this.hr.Remove("Pesho");

		Assert.True(result);
		Assert.AreEqual(0, this.hr.Heroes.Count);
    }

	[Test]
	public void GetHeroWithHighestLevelMethodShouldReturnHeroCorrectly()
    {
		var newHero = new Hero("Gosho", 100);
		this.hr.Create(newHero);

		var result = this.hr.GetHeroWithHighestLevel();

		Assert.AreEqual(newHero, result);
    }

	[Test]
	public void GetHeroMethodShouldReturnHeroCorrectly()
    {
		var result = this.hr.GetHero("Pesho");

		Assert.AreEqual(hero, result);
    }
}