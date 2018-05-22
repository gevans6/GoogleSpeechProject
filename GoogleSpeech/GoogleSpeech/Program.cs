using Google.Cloud.Speech.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSpeech
{
    class Program
    {
        public static void Main(string[] args)
        {
            string credential_path = @"C:\Users\iGuest\Desktop\My Project-09c8d322a31f.json";
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);

            var speech = SpeechClient.Create();
            var response = speech.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                SampleRateHertz = 44100,
                LanguageCode = "en",
                EnableWordTimeOffsets = true,
            }, RecognitionAudio.FromFile("gettysburg_address-trim-mono.flac"));
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
            Console.ReadLine();
        }
    }
}

