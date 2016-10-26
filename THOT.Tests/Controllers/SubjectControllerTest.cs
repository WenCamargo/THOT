using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using THOT;
using THOT.Models;
using THOT.Controllers;

namespace THOT.Tests.Controllers
{
    [TestClass]
    public class SubjectControllerTest
    {
        public List<Subject> subjectList = new List<Subject>();

        public void seed()
        {
            subjectList.Add(new Subject()
            {
                SubjectId = 1,
                Name = "MATH",
            });

            subjectList.Add(new Subject()
            {
                SubjectId = 2,
                Name = "BIO",
            });

            subjectList.Add(new Subject()
            {
                SubjectId = 3,
                Name = "PHY",
            });

            subjectList.Add(new Subject()
            {
                SubjectId = 4,
                Name = "ENG",
            });
        }

        [TestMethod]
        public void Index()
        {
            seed();

            var result = subjectList;
            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            seed();

            var subject = new Subject()
            {
                SubjectId = 6,
                Name = "ESP"
            };

            subjectList.Add(subject);

            var result = subjectList.Where(x => x.SubjectId == 6).First();

            Assert.IsNotNull(result);
            Assert.AreEqual(subject, result);
        }
    }
}
