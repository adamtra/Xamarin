namespace PatientsStory.Validators
{
    public static class RegexPatterns
    {
        public const string descriptionPattern = "^.{1,100}$";
        public const string genderPattern = "^(M|K){1}$";
        public const string namePattern = "^[A-ZĆŁŚŹŻ][a-ząćęłńóśźżA-ZĄĆĘŁŃÓŚŹŻ-]{2,29}$";
        public const string peselPattern = "^([0-9]{2})(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])([0-9]{5})$";
        public const string pricePattern = "^([0-9]{1,5})([.]{0,1})([0-9]{0,2})$";
    }
}