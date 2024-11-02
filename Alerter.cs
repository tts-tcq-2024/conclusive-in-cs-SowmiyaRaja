public class Alerter
    public enum AlertTarget { 
        TO_CONTROLLER, 
        TO_EMAIL }

    public static void checkAndAlert(AlertTarget alertTarget, BreachDetector.CoolingType coolingType, double temperatureInC)
    {
        BreachDetector.BreachType breachType = BreachDetector.classifyTemperatureBreach(coolingType, temperatureInC);
        if (alertTarget == AlertTarget.TO_CONTROLLER)
            sendToController(breachType);
        else
            sendToEmail(breachType);
    }

    private static void sendAlertToController(BreachDetector.BreachType breachType)
    {
      const ushort header = 0xfeed;
      Console.WriteLine("{} : {}\n", header, breachType);
    }

    private static void sendAlertToEmail(BreachDetector.BreachType breachType)
    {
        String recipient = "a.b@c.com";
        if (breachType != BreachDetector.BreachType.NORMAL)
            Console.WriteLine("To: {0}\n Hi, the temperature is {1}\n", recipient,
                breachType == BreachDetector.BreachType.TOO_LOW ? "too low" : "too high");
    }
}
