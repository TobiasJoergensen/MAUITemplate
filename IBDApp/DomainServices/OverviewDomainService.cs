namespace IBDApp.Business
{
    public class OverviewDomainService
    {
        /// <summary>
        /// Formats a string of name and age by comma seperation.
        /// </summary>
        /// <param name="name">Name of the user.</param>
        /// <param name="age">Age of the user.</param>
        /// <returns></returns>
        public string FormatNameAndAge(string name, int age)
        {
            return $"{name}, {age.ToString()}";
        }

        /// <summary>
        /// Formats a description to a constant if it is under 5 characters.
        /// </summary>
        /// <param name="description">Description of the user.</param>
        /// <returns></returns>
        public string FormatDescription(string description)
        {
            if (description.Length < 5)
            {
                return "No description yet";
            }

            return description;
        }
    }
}
