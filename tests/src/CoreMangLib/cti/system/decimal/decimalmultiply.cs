using System;
/// <summary>
/// Multiply(System.Decimal,System.Decimal)
/// </summary>
public class DecimalMultiply
{
    #region Public Methods
    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        TestLibrary.TestFramework.LogInformation("[Negtive]");
        retVal = NegTest1() && retVal;
        retVal = NegTest2() && retVal;
        return retVal;
    }

    #region Positive Test Cases
    public bool PosTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest1: check Two Decimal Multiply.");

        try
        {
            Decimal m1 = 1000m;
            Decimal m2 = 7m;
            Decimal expectValue = 7000m;
            Decimal actualValue = m1*m2;
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.1", "Multiply should  return " + expectValue);
                retVal = false;
            }
            m1 = -1000m;
            m2 = 7m;
            expectValue = -7000m;
            actualValue = m1 * m2;
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.2", "Multiply should  return " + expectValue);
                retVal = false;
            }


            m1 = 123.0000000m;
            m2 = 0.0012300m;
            expectValue = 0.15129000000000m;
            actualValue = m1 * m2;
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.3", "Multiply should  return " + expectValue);
                retVal = false;
            }


            m1 = 12345678900000000m;
            m2 = 0.0000000012345678m;
            expectValue = 15241577.6390794200000000m;
            actualValue = m1 * m2;
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.4", "Multiply should  return " + expectValue);
                retVal = false;
            }


            m1 = 123456789.0123456789m;
            m2 = 123456789.1123456789m;
            expectValue = 15241578765584515.651425087878m;
            actualValue = m1 * m2;
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.5", "Multiply should  return " + expectValue);
                retVal = false;
            }
         
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
   
    #endregion
    #region NegiTive Test
    public bool NegTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest1: The return value is  greater than MaxValue.");

        try
        {
            Decimal m1 = Decimal.MaxValue;
            Decimal m2 = Decimal.MaxValue;
            Decimal actualValue = m1 * m2;
            TestLibrary.TestFramework.LogError("101.1", "OverflowException should be caught.");
            retVal = false;
        }
        catch (OverflowException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("101.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool NegTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest2: The return value is less than MinValue .");

        try
        {
            Decimal m1 = Decimal.MinValue;
            Decimal m2 = Decimal.MaxValue;
            Decimal actualValue = m1 * m2;
            TestLibrary.TestFramework.LogError("102.1", "OverflowException should be caught.");
            retVal = false;
        }
        catch (OverflowException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("102.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    #endregion
    #endregion

    public static int Main()
    {
        DecimalMultiply test = new DecimalMultiply();

        TestLibrary.TestFramework.BeginTestCase("DecimalMultiply");

        if (test.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    #region private method
    public TypeCode GetExpectValue(Decimal myValue)
    {
        return TypeCode.Decimal;
    }
    #endregion
}
