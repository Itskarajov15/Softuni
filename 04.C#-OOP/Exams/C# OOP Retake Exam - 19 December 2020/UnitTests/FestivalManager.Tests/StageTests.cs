// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
	{
		private Stage stage;

		[SetUp]
		public void Setup()
		{
			this.stage = new Stage();
		}

		[Test]
	    public void AddPerformerMethodShouldThrowExceptionWhenPerformerIsNull()
	    {
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
		}

		[Test]
		public void AddPerformerMethodShouldThrowExceptionWhenPerformerAgeIsLessThan18()
        {
			Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(new Performer("Gosho", "Goshev", 15)));
        }

		[Test]
		public void AddPerformerMethodShouldAddPerformersCorrectly()
        {
			var performer = new Performer("Gosho", "Goshev", 20);

			this.stage.AddPerformer(performer);

			Assert.AreEqual(1, this.stage.Performers.Count);
			Assert.That(this.stage.Performers.FirstOrDefault().Equals(performer));
        }

		[Test]
		public void AddSongMethodShouldThrowExceptionWhenSongIsNull()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
		}

		[Test]
		public void AddSongMethodShouldThrowExceptionWhenDurationIsLessThan1()
        {
			Assert.Throws<ArgumentException>(() => this.stage.AddSong(new Song("SongName", new TimeSpan(0, 0, 34))));
        }

		[Test]
		public void AddSongMethodShouldAddSongsCorrectly()
        {
			var song = new Song("Song", new TimeSpan(0, 1, 45));
			var performer = new Performer("Gosho", "Goshev", 20);

			this.stage.AddSong(song);
			this.stage.AddPerformer(performer);

			var result = this.stage.AddSongToPerformer("Song", "Gosho Goshev");

			Assert.AreEqual("Song (01:45) will be performed by Gosho Goshev", result);
        }

		[Test]
		[TestCase(null, "Gosho Goshev")]
		[TestCase("Song", null)]
		public void AddSongToPerformerMethodShouldThrowExceptionWhenArgumentsAreNull(string songName, string performerName)
        {
			Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(songName, performerName));
        }

		[Test]
		public void PlayMethodShouldReturnCorrectMessage()
        {
			this.stage.AddPerformer(new Performer("Gosho", "Goshev", 20));
			this.stage.AddSong(new Song("Song", new TimeSpan(0, 1, 45)));
			this.stage.AddSongToPerformer("Song", "Gosho Goshev");

			var result = this.stage.Play();

			Assert.AreEqual("1 performers played 1 songs", result);
        }
	}
}