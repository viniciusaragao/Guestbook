﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Guestbook.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Guestbook;
using Guestbook.Controllers;

namespace Guestbook.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_RendersView()
        {
            var controller = new GuestbookController(
            new FakeGuestbookRepository());
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Index_gets_most_recent_entries()
        {
            var controller = new GuestbookController(
            new FakeGuestbookRepository());
            var result = (ViewResult)controller.Index();
            var guestbookEntries = (IList<GuestbookEntry>)result.Model;
            Assert.AreEqual(1, guestbookEntries.Count);
        }
    }
}
