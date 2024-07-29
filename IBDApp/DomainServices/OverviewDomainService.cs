namespace IBDApp.Business
{
    public class OverviewDomainService
    {
        //All testable logic is placed in here in favor of having it in our model or our viewmodel. It's a hard requirement that all the used values are put as formal parameters
        public string FormatNameAndAge(string name, int age)
        {
            return $"{name}, {age.ToString()}";
        }

        public string FormatDescription(string description)
        {
            //If description is shorter than 5, we return a default text
            if (description.Length < 5)
            {
                return "No description yet";
            }

            return description;
        }
    }
}
