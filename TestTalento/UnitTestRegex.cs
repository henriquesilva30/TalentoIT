using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using TalentoIT.Controllers;
using TalentoIT.Entities;
using TalentoIT.Models;

namespace TestTalento
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //Testar padrões de Regex
            
            //email
            string input = "simaoferreira@ipvc.pt";
            string input2 = "simao.pt";
            string pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(input, pattern));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(input2, pattern));
            
            //password
            string pass = "123456";
            string pass2 = "A123456";
            string patternPass = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{4,}$";
            
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(pass2, patternPass));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(pass, patternPass));
            
            //Ano
            string ano = "2000";
            string ani = "15";
            string patternAno = @"\d{4}$";
            
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(ano, patternAno));
            Assert.IsFalse(System.Text.RegularExpressions.Regex.IsMatch(ani, patternAno));


        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}