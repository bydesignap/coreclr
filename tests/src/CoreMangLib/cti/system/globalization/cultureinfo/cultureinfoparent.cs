using System;
using System.Globalization;
/// <summary>
///Parent
/// </summary>
public class CultureInfoParent
{
    public static int Main()
    {
        CultureInfoParent CultureInfoParent = new CultureInfoParent();

        TestLibrary.TestFramework.BeginTestCase("CultureInfoParent");
        if (CultureInfoParent.RunTests())
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

    public bool RunTests()
    {
        bool retVal = true;
        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest1: Specific Cultures, the Parent culture of 'en-US' should  be CultureInfo('en').");
        try
        {
          
            CultureInfo myExpectParentCulture = new CultureInfo("en");
            CultureInfo myTestCulture = new CultureInfo("en-us");

            if (!myTestCulture.Parent.Equals(myExpectParentCulture))
            {
                TestLibrary.TestFramework.LogError("001", "the Parent culture of 'en-US'  should  be ("+myExpectParentCulture.EnglishName+"), actual("+myTestCulture.Parent.EnglishName+").");
                retVal = false;
            }

         }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest2: Neutral Cultures, the Parent culture of neutral should be CultureInfo('').");
        try
        {

            if (!TestLibrary.Utilities.IsWindows)
            {
                CultureInfo myTestCulture = new CultureInfo("en");
                CultureInfo myExpectParent = CultureInfo.InvariantCulture;
                {
                    if (!myTestCulture.Parent.Equals(myExpectParent))
                    {
                        TestLibrary.TestFramework.LogError("003", "the Parent culture of neutral should be CultureInfo('') ");
                        retVal = false;
                    }
                }
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("004", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest3()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest3: Invariant culture, the Parent culture of invariant should be CultureInfo('')");
        try
        {

            CultureInfo myExpectParent1 = new CultureInfo("");
            CultureInfo myTestCulture = CultureInfo.InvariantCulture;
            if (!myTestCulture.Parent.Equals(myExpectParent1))
                {
                    TestLibrary.TestFramework.LogError("005", "the Parent culture of Invariant Culture should be CultureInfo('')");
                    retVal = false;
                }
           
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("006", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
}

