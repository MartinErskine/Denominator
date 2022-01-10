using System;
using Denominator.Service;
using NUnit.Framework;

namespace Denominator.Tests
{
    public class Tests
    {
        private IDenominatorService denominatorService;

        [SetUp]
        public void Setup()
        {
            denominatorService = new DenominatorService();
        }

        [Test]
        public void CostFivePoundsAndFiftyPenceTenderedTwentyPounds()
        {
            var args = new ApplicationArguments
            {
                Cost = "5.50",
                Tendered = "20"
            };

            var result = denominatorService.GetChange(args);

            Assert.That(result, Is.EqualTo("Your Change is:\n1 x £10\n2 x £2\n1 x 50p\n"));
        }

        [Test]
        public void CostThreePoundsAndEightyFivePenceTenderedFifteenPounds()
        {
            var args = new ApplicationArguments
            {
                Cost = "3.85",
                Tendered = "15"
            };

            var result = denominatorService.GetChange(args);

            Assert.That(result, Is.EqualTo("Your Change is:\n1 x £10\n1 x £1\n1 x 10p\n1 x 5p\n"));
        }

        [Test]
        public void CostElevenPoundsAndThirtyPenceTenderedTwentyPounds()
        {
            var args = new ApplicationArguments
            {
                Cost = "11.30",
                Tendered = "20"
            };

            var result = denominatorService.GetChange(args);

            Assert.That(result, Is.EqualTo("Your Change is:\n1 x £5\n1 x £2\n1 x £1\n1 x 50p\n1 x 20p\n"));
        }

        [Test]
        public void InvalidCostArgumentPassed()
        {
            var args = new ApplicationArguments
            {
                Cost = null,
                Tendered = "20"
            };

            var result = denominatorService.GetChange(args);

            Assert.That(result, Is.EqualTo("No Arguments passed or were passed incorrectly!"));

            //Exception Handled, no longer required.
            //Assert.Throws<FormatException>(() => denominatorService.GetChange(args));
        }

        [Test]
        public void InvalidTenderedArgumentPassed()
        {
            var args = new ApplicationArguments
            {
                Cost = "5.50",
                Tendered = null
            };

            var result = denominatorService.GetChange(args);

            Assert.That(result, Is.EqualTo("No Arguments passed or were passed incorrectly!"));
        }
    }
}