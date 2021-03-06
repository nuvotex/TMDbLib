﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMDbLib.Objects.Find;

namespace TMDbLibTests
{
    [TestClass]
    public class ClientFindTests
    {
        private TestConfig _config;
        private const int tmdbTerminatorId = 218;
        private const string imdbTerminatorId = "tt0088247";
        private const int tmdbBreakingBadId = 1396;
        private const string tvdbBreakingBadId = "81189";
        private const string imdbBreakingBadId = "tt0903747";
        private const string tvRageBreakingBadId = "18164";
        private const string freebaseBreakingBadId = "en/breaking_bad";
        private const string freebaseMidBreakingBadId = "m/03d34x8";

        /// <summary>
        /// Run once, on every test
        /// </summary>
        [TestInitialize]
        public void Initiator()
        {
            _config = new TestConfig();
        }

        [TestMethod]
        public void TestFindImdbMovie()
        {
            var result = _config.Client.Find(FindExternalSource.Imdb, imdbTerminatorId);
            Assert.AreEqual(1, result.Result.MovieResults.Count);
            Assert.AreEqual(tmdbTerminatorId, result.Result.MovieResults[0].Id);
        }

        [TestMethod]
        public void TestFindTvdbTvShow()
        {
            var result = _config.Client.Find(FindExternalSource.TvDb, tvdbBreakingBadId);
            Assert.AreEqual(1, result.Result.TvResults.Count);
            Assert.AreEqual(tmdbBreakingBadId, result.Result.TvResults[0].Id);
        }

        [TestMethod]
        public void TestFindImdbTvShow()
        {
            var result = _config.Client.Find(FindExternalSource.Imdb, imdbBreakingBadId);
            Assert.AreEqual(1, result.Result.TvResults.Count);
            Assert.AreEqual(tmdbBreakingBadId, result.Result.TvResults[0].Id);
        }

        [TestMethod]
        public void TestFindTvRageTvShow()
        {
            var result = _config.Client.Find(FindExternalSource.TvRage, tvRageBreakingBadId);
            Assert.AreEqual(1, result.Result.TvResults.Count);
            Assert.AreEqual(tmdbBreakingBadId, result.Result.TvResults[0].Id);
        }

        [TestMethod]
        public void TestFindFreebaseTvShow()
        {
            var result = _config.Client.Find(FindExternalSource.FreeBaseId, freebaseBreakingBadId);
            Assert.AreEqual(1, result.Result.TvResults.Count);
            Assert.AreEqual(tmdbBreakingBadId, result.Result.TvResults[0].Id);
        }

        [TestMethod]
        public void TestFindFreebaseMidTvShow()
        {
            var result = _config.Client.Find(FindExternalSource.FreeBaseMid, freebaseMidBreakingBadId);
            Assert.AreEqual(1, result.Result.TvResults.Count);
            Assert.AreEqual(tmdbBreakingBadId, result.Result.TvResults[0].Id);
        }
    }
}
