using System;

namespace ZhrachkaBot.Main
{
    public class InPiterWeDrinkStrategy : SayStrategy
    {
        public override string Say(string phrase)
        {
            var language = GetPhraseLanguage(phrase);

            return BuildResponse(language);
        }

        private static PhraseLanguage GetPhraseLanguage(string phrase)
        {
            if (phrase.Contains("в пітєрє", StringComparison.InvariantCultureIgnoreCase)
                || phrase.Contains("в пітері", StringComparison.InvariantCultureIgnoreCase))
            {
                return PhraseLanguage.Ukrainian;
            }

            if (phrase.Contains("in piter", StringComparison.InvariantCultureIgnoreCase))
            {
                return PhraseLanguage.English;
            }

            return PhraseLanguage.Unknown;
        }

        private static string BuildResponse(PhraseLanguage language)
        {
            switch (language)
            {
                case PhraseLanguage.Ukrainian:
                    return "- Піть";
                case PhraseLanguage.English:
                    return "- We Drink";
                case PhraseLanguage.Unknown:
                    return null;
            }

            return null;
        }
    }
}
