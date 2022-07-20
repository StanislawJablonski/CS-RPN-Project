using NUnit.Framework;
using System;
using RPNCalulator;

namespace RPNTest {
	[TestFixture]
	public class RPNTest {
		private RPN _sut;
		[SetUp]
		public void Setup() {
			_sut = new RPN();
		}
		[Test]
		public void CheckIfTestWorks() {
			Assert.Pass();
		}

		[Test]
		public void CheckIfCanCreateSut() {
			Assert.That(_sut, Is.Not.Null);
		}

		[Test]
		public void SingleDigitOneInputOneReturn() {
			var result = _sut.EvalRPN("1");

			Assert.That(result, Is.EqualTo(1));

		}
		[Test]
		public void SingleDigitOtherThenOneInputNumberReturn() {
			var result = _sut.EvalRPN("2");

			Assert.That(result, Is.EqualTo(2));

		}
		[Test]
		public void TwoDigitsNumberInputNumberReturn() {
			var result = _sut.EvalRPN("12");

			Assert.That(result, Is.EqualTo(12));

		}
		[Test]
		public void TwoNumbersGivenWithoutOperator_ThrowsExcepton() {
			Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("1 2"));

		}
		[Test]
		public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("1 2 +");

			Assert.That(result, Is.EqualTo(3));
		}
		[Test]
		public void OperatorTimes_AddingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("2 2 *");

			Assert.That(result, Is.EqualTo(4));
		}
		[Test]
		public void OperatorMinus_SubstractingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("1 2 -");

			Assert.That(result, Is.EqualTo(1));
		}
		[Test]
		public void ComplexExpression() {
			var result = _sut.EvalRPN("15 7 1 1 + - / 3 * 2 1 1 + + -");

			Assert.That(result, Is.EqualTo(4));
		}
		[Test]
		public void OperatorFactorial_CalculatingOneNumber_ReturnCorrectResult() 
		{
			var result = _sut.EvalRPN("6 !");

			Assert.That(result, Is.EqualTo(720));
		}
		[Test]
		public void OperatorFactorial_CalculatingNumberZero_ReturnCorrectResult() 
		{
			var result = _sut.EvalRPN("0 !");

			Assert.That(result, Is.EqualTo(1));
		}
		[Test]
		public void OperatorFactorial_CalculatingTwoNumbers_ThrowsException() 
		{
			Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("4 5 !"));
		}

		[Test]
		public void OperatorFactorial_UsingNegativeInput_ThrowsException()
		{
			Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("-2 !"));
		}
		[Test]
		public void OperatorDivision_DividingTwoNumbers_ReturnCorrectResult()
		{
			var result = _sut.EvalRPN("3 9 /");
			
			Assert.That(result, Is.EqualTo(3));
		}
		[Test]
		public void OperatorDivision_DividingByZero_ThrowException() {
			Assert.Throws<DivideByZeroException>(() => _sut.EvalRPN("0 10 /"));
		}
		[Test]
		public void OperatorDivision_DividerIsBiggerThanDivisor_ReturnCorrectResult() {
			var result = _sut.EvalRPN("7 5 /");

			Assert.That(result, Is.EqualTo(0));
		}
		[Test]
		public void OperatorPlus_AddingBinaryNumbers_ReturnCorrectResult()
		{
			var result = _sut.EvalRPN("B110 B111 +");
			
			Assert.That(result, Is.EqualTo(13));
		}
		[Test]
		public void OperatorMinus_SubstractingBinaryNumbers_ReturnCorrectResult()
		{
			var result = _sut.EvalRPN("B110 B111 -");
			
			Assert.That(result, Is.EqualTo(1));
		}
		[Test]
		public void InvalidInput_ThrowsException()
		{
			Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("XD 4 +"));
		}
		[Test]
		public void OperatorPlus_AddingBinaryAndDecimal_ReturnCorrectResult()
		{
			var result = _sut.EvalRPN("B110 D10 +");
			
			Assert.That(result, Is.EqualTo(16));
		}
		[Test]
		public void OperatorPlus_AddingBinaryAndDecimalWrongInput_ThrowsException()
		{
			Assert.Throws<ArgumentException>(() => _sut.EvalRPN("BXD D +"));
		}
	}
}