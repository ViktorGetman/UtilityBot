using Microsoft.VisualBasic;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using VoiceTexterBot.Services;

namespace VoiceTexterBot.Controllers
{
    public class Class1
    {
        private readonly IStorage _memoryStorage; // Добавим это
        private readonly ITelegramBotClient _telegramClient;
        

        public Class1 (ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage; // и это
        }

        public async Task Handle(Message message, CancellationToken ct)
        {          

            string userLanguageCode = _memoryStorage.GetSession(message.Chat.Id).LanguageCode; // Здесь получим язык из сессии пользователя

            if(userLanguageCode == "ru")
                
            {
                await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Длина сообщения: {message.Text.Length} знаков");
            }

        }
    }
}