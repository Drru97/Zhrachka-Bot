using System;

namespace ZhrachkaBot.Main
{
    public class InLvivWeDegustateStrategy : SayStrategy
    {
        public override string Say(string phrase)
        {
            var language = GetPhraseLanguage(phrase);

            return BuildResponse(language);
        }

        private static PhraseLanguage GetPhraseLanguage(string phrase)
        {
            if (phrase.Contains("ві львові", StringComparison.InvariantCultureIgnoreCase)
                || phrase.Contains("ві львови", StringComparison.InvariantCultureIgnoreCase)
                || phrase.Contains("у львові", StringComparison.InvariantCultureIgnoreCase)
                || phrase.Contains("у львови", StringComparison.InvariantCultureIgnoreCase))
            {
                return PhraseLanguage.Ukrainian;
            }

            if (phrase.Contains("in lviv", StringComparison.InvariantCultureIgnoreCase))
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
                    return "- Дегустувать";
                case PhraseLanguage.English:
                    return "- We taste";
                case PhraseLanguage.Unknown:
                    return null;
            }

            return null;
        }
    }
}
