using System;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace ZhrachkaBot.Main
{
    internal class Program
    {
        private static TelegramBotClient _bot;
        private static HttpClient _http;
        private static RandomNumberGenerator<Place2> _places;

        private static async Task Main()
        {
            await InitializeBotAsync();
            InitPlaces();

            HandleCommand();

            _bot.StartReceiving();
            await Task.Delay(int.MaxValue);
        }

        private static async Task InitializeBotAsync()
        {
            _bot = new TelegramBotClient("527537162:AAExRQOYjSOa6N-PZIgpbapSrSCl2GP-BJ0");
            var me = await _bot.GetMeAsync();

            _http = new HttpClient();

            if (me != null)
            {
                Console.WriteLine($"Bot initialized: {me.Username}");
            }
        }

        private static void HandleCommand()
        {
            _bot.OnMessage += async (sender, e) =>
            {
                if (e.Message.Type == MessageType.Text)
                {
                    if (e.Message.Text.Contains(Phrases.EatCommand,
                        StringComparison.InvariantCultureIgnoreCase))
                    {
                        var place = _places.NextItem();
                        var location = place.Location;
                        Console.WriteLine($"Received message {e.Message.Text} in chat {e.Message.Chat.Title}");
                        Console.WriteLine($"Place to go: {place.Name}");

                        var message = $"Йдемо їсти в: {place.Name}";
                        var image = await DownloadPhotoAsync(place.Url);

                        await _bot.SendTextMessageAsync(e.Message.Chat, message);
                        await _bot.SendLocationAsync(e.Message.Chat, (float) location.Latitude,
                            (float) location.Longitude);
                        await _bot.SendPhotoAsync(e.Message.Chat, image);
                    }

                    var drinkStrategy = new InPiterWeDrinkStrategy();
                    var drinkMessage = drinkStrategy.Say(e.Message.Text);
                    if (drinkMessage != null)
                    {
                        await _bot.SendTextMessageAsync(e.Message.Chat, drinkMessage);
                    }
                    
                    var tasteStrategy = new InLvivWeDegustateStrategy();
                    var tasteMessage = tasteStrategy.Say(e.Message.Text);
                    if (tasteMessage != null)
                    {
                        await _bot.SendTextMessageAsync(e.Message.Chat, tasteMessage);
                    }
                }
            };
        }

        private static void InitPlaces()
        {
            _places = new RandomNumberGenerator<Place2>();

            foreach (var place in Phrases.Places)
            {
                _places.Add(place.Percentage, place);
            }
        }

        private static async Task<InputOnlineFile> DownloadPhotoAsync(string url)
        {
            var stream = await _http.GetStreamAsync(url);

            return new InputOnlineFile(stream);
        }
    }
}
