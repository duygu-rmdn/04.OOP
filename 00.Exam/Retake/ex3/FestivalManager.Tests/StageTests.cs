// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void test1()
	    {
			Performer performer = null;
			TimeSpan timeSpan = new TimeSpan();
			Song song = new Song("name", timeSpan);
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
		}

		[Test]
		public void test2()
		{
			Performer performer = new Performer("zxsz", "lname", 12);
			TimeSpan timeSpan = new TimeSpan();
			Song song = null;
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() => stage.AddSong(song));
		}

		[Test]
		public void test3()
		{
		 Performer performer = new Performer("zxsz", "lname", 12); ;
			TimeSpan timeSpan = new TimeSpan();
			Song song = new Song("name", timeSpan);
			Stage stage = new Stage();

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
		}
		

	}
}