public class Alerter
    public enum AlertTarget { 
        TO_CONTROLLER, 
        TO_EMAIL }

    public static void checkAndAlert(AlertTarget alertTarget, BreachFinder.CoolingType coolingType, double temperatureInC)
    {
        BreachFinder.BreachType breachType = BreachFinder.classifyTemperatureBreach(coolingType, temperatureInC);
        if (alertTarget == AlertTarget.TO_CONTROLLER)
            sendToController(breachType);
        else
            sendToEmail(breachType);
    }

    private static void sendAlertToController(BreachFinder.BreachType breachType)
    {
      const ushort header = 0xfeed;
      Console.WriteLine("{} : {}\n", header, breachType);
    }

    private static void sendAlertToEmail(BreachFinder.BreachType breachType)
    {
        String recipient = "a.b@c.com";
        if (breachType != BreachFinder.BreachType.NORMAL)
            Console.WriteLine("To: {0}\n Hi, the temperature is {1}\n", recipient,
                breachType == BreachFinder.BreachType.TOO_LOW ? "too low" : "too high");
    }
}
