using demo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace demo
{// start of namespace

    // ── DELEGATE declaration (satisfies OOP delegate requirement) ──
    public delegate void ChatResponseDelegate(string name, string message);

    public partial class MainWindow : Window
    {// start of class

        // Generic collections
        ArrayList reply = new ArrayList();
        ArrayList ignore = new ArrayList();

        // Other class instances
        user_name check_name = new user_name();

        // ── Variables ──
        string username = string.Empty;
        string last_topic = string.Empty;   // tracks the last keyword topic discussed
        int counting = 0;              // interest reminder counter

        // Delegate instance wired to the error_method
        private ChatResponseDelegate chatDelegate;

        // ── Sentiment keywords ──
        private readonly HashSet<string> sentimentWords = new HashSet<string>
        {
            "worried","concerned","scared","afraid","overwhelmed",
            "curious","frustrated","confused","angry","sad","happy","excited"
        };

        // ── Conversation-flow trigger words ──
        private readonly HashSet<string> moreWords = new HashSet<string>
        {
            "more","another","again","explain","elaborate","expand",
            "detail","details","continue","further","else","tip","tips","repeat"
        };

        // ── Constructor ──
        public MainWindow()
        {
            InitializeComponent();

            new respond(reply, ignore) { };

            // Wire delegate to error_method
            chatDelegate = new ChatResponseDelegate(error_method);

            // Play voice greeting
            voice_greeting greet = new voice_greeting();
            greet.greet();
        }


        // ── PROCEED event handler ──
        private void proceed(object sender, RoutedEventArgs e)
        {
            home_grid.Visibility = Visibility.Hidden;
            username_grid.Visibility = Visibility.Visible;
        }


        // ── SUBMIT NAME event handler ──
        private void submit_name(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernames_input.Text))
            {
                error_method("ChatBot", "Please enter a username to continue.");
                return;
            }

            username = check_name.submit_name(usernames_input, chats);

            username_grid.Visibility = Visibility.Hidden;
            chat_grid.Visibility = Visibility.Visible;
        }


        // ── SEND event handler ──
        private void send(object sender, RoutedEventArgs e)
        {
            string rawQuestion = question.Text.ToString().Trim();

            if (string.IsNullOrWhiteSpace(rawQuestion))
            {
                chatDelegate("ChatBot", "Please enter a question.");
                return;
            }

            // Show the user's message in the chat
            chatDelegate(username, rawQuestion);

            // Clean the input before processing
            string cleanedQuestion = RemoveSpecialCharacters(rawQuestion);

            // Interest counter / reminder logic
            auto_show_interest();

            // Process the cleaned question
            ai_check(cleanedQuestion);
        }


        // ── ENTER KEY shortcut in the question box ──
        private void question_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                send(sender, new RoutedEventArgs());
        }


        // ── MAIN AI LOGIC ──
        private void ai_check(string questions)
        {
            if (string.IsNullOrWhiteSpace(questions))
            {
                chatDelegate("ChatBot", "Please enter a valid question.");
                question.Clear();
                return;
            }

            string[] words = questions.ToLower()
                .Split(new char[] { ' ', ',', '.', '?', '!', ';', ':' },
                       StringSplitOptions.RemoveEmptyEntries);

            bool found = false;
            string message = string.Empty;
            Random indexer = new Random();
            List<string> per_word = new List<string>();
            List<string> answers_found = new List<string>();

            // ── 1. Check for conversation-flow requests ("more", "another tip", etc.) ──
            bool isMoreRequest = words.Any(w => moreWords.Contains(w.ToLower()));

            if (isMoreRequest && !string.IsNullOrEmpty(last_topic))
            {
                // Re-use the last topic to find a fresh answer
                List<string> topicAnswers = new List<string>();
                foreach (string answer in reply)
                {
                    if (answer.ToLower().Contains(last_topic))
                        topicAnswers.Add(answer);
                }

                if (topicAnswers.Count > 0)
                {
                    string extra = topicAnswers[indexer.Next(topicAnswers.Count)];
                    chatDelegate("ChatBot", "Here is another tip on " + last_topic + ": " + extra);
                    question.Clear();
                    return;
                }
            }

            // ── 2. Check for sentiment words first ──
            string detectedSentiment = string.Empty;
            foreach (string word in words)
            {
                if (sentimentWords.Contains(word.ToLower()))
                {
                    detectedSentiment = word.ToLower();
                    break;
                }
            }

            if (!string.IsNullOrEmpty(detectedSentiment))
            {
                // Find a matching empathy response
                List<string> sentimentAnswers = new List<string>();
                foreach (string answer in reply)
                {
                    if (answer.ToLower().StartsWith(detectedSentiment))
                        sentimentAnswers.Add(answer);
                }

                if (sentimentAnswers.Count > 0)
                {
                    string empathy = sentimentAnswers[indexer.Next(sentimentAnswers.Count)];
                    chatDelegate("ChatBot", empathy);
                }

                // If the user is worried/scared/concerned/overwhelmed/frustrated/confused,
                // automatically follow up with a relevant tip (no re-entry required).
                HashSet<string> needsTip = new HashSet<string>
                {
                    "worried","concerned","scared","afraid","overwhelmed","frustrated","confused"
                };

                if (needsTip.Contains(detectedSentiment))
                {
                    // Look for a cybersecurity keyword in the same sentence
                    string autoTopic = string.Empty;
                    foreach (string word in words)
                    {
                        if (word.Length >= 3 && !ignore.Contains(word) && !sentimentWords.Contains(word))
                        {
                            // Check if any answer contains this word
                            bool hasTopic = false;
                            foreach (string ans in reply)
                            {
                                if (ans.ToLower().Contains(word.ToLower()))
                                { hasTopic = true; break; }
                            }
                            if (hasTopic)
                            { autoTopic = word; break; }
                        }
                    }

                    // If no specific topic found, default to "scam" as a common concern
                    if (string.IsNullOrEmpty(autoTopic))
                        autoTopic = "scam";

                    List<string> tipAnswers = new List<string>();
                    foreach (string answer in reply)
                    {
                        if (answer.ToLower().Contains(autoTopic))
                            tipAnswers.Add(answer);
                    }

                    if (tipAnswers.Count > 0)
                    {
                        last_topic = autoTopic;
                        string tip = tipAnswers[indexer.Next(tipAnswers.Count)];
                        chatDelegate("ChatBot", "Here is a tip that may help: " + tip);
                    }
                }

                question.Clear();
                return;
            }

            // ── 3. Interest storage ──
            foreach (string word in words)
            {
                if (word.Contains("interested"))
                {
                    string store_interests = string.Empty;
                    bool found_interest = false;
                    HashSet<string> currentInterests = new HashSet<string>();

                    foreach (string interest in words)
                    {
                        string clean = interest.ToLower().Trim();
                        clean = Regex.Replace(clean, @"[^a-zA-Z0-9\s]", "");

                        if (!ignore.Contains(clean) && clean != "interested" &&
                            clean != "and" && clean != "in" &&
                            clean.Length >= 3)
                        {
                            found_interest = true;
                            currentInterests.Add(clean);
                        }
                    }

                    store_interests = string.Join(", ", currentInterests);

                    if (found_interest && !string.IsNullOrWhiteSpace(store_interests))
                    {
                        string filename = "interested_topic.txt";
                        bool userFound = false;

                        if (File.Exists(filename))
                        {
                            string[] lines = File.ReadAllLines(filename);
                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (lines[i].StartsWith(username))
                                {
                                    userFound = true;
                                    string existing = lines[i]
                                        .Replace(username + " interested in:", "")
                                        .ToLower();

                                    HashSet<string> existingSet = new HashSet<string>(
                                        existing.Split(',')
                                                .Select(x => x.Trim())
                                                .Where(x => x != ""));

                                    foreach (string item in currentInterests)
                                        existingSet.Add(item);

                                    string finalList = string.Join(", ", existingSet);
                                    lines[i] = username + " interested in: " + finalList;
                                    File.WriteAllLines(filename, lines);

                                    message += "Great — I have added \"" + store_interests +
                                               "\" to your interests. ";
                                    break;
                                }
                            }
                        }

                        if (!userFound)
                        {
                            File.AppendAllText(filename,
                                username + " interested in: " + store_interests + "\n");

                            message += "Great! I will remember that you are interested in " +
                                       store_interests + ". It is a crucial part of staying safe online. ";
                        }

                        // Immediately share a tip related to the stored interest
                        string firstInterest = currentInterests.FirstOrDefault() ?? string.Empty;
                        if (!string.IsNullOrEmpty(firstInterest))
                        {
                            List<string> relatedTips = new List<string>();
                            foreach (string ans in reply)
                            {
                                if (ans.ToLower().Contains(firstInterest))
                                    relatedTips.Add(ans);
                            }
                            if (relatedTips.Count > 0)
                            {
                                last_topic = firstInterest;
                                message += "As someone interested in " + firstInterest +
                                           ", here is a tip: " +
                                           relatedTips[indexer.Next(relatedTips.Count)];
                            }
                        }

                        chatDelegate("ChatBot", message.Trim());
                        question.Clear();
                        return;
                    }
                    else
                    {
                        chatDelegate("ChatBot",
                            "Please specify what you are interested in — for example: " +
                            "\"I am interested in privacy\".");
                        question.Clear();
                        return;
                    }
                }
            }

            // ── 4. Keyword matching ──
            foreach (string word in words)
            {
                if (word.Length < 3 || ignore.Contains(word.ToLower()))
                    continue;

                per_word.Clear();

                bool wordFound = false;
                foreach (string answer in reply)
                {
                    if (answer.ToLower().Contains(word))
                    {
                        wordFound = true;
                        per_word.Add(answer);
                    }
                }

                if (wordFound && per_word.Count > 0)
                {
                    found = true;
                    last_topic = word; // remember topic for conversation flow
                    int indexing = indexer.Next(0, per_word.Count);
                    answers_found.Add(per_word[indexing]);
                }
            }

            // ── 5. Display results ──
            if (found && answers_found.Count > 0)
            {
                answers_found = answers_found.Distinct().ToList();
                foreach (string per_answer in answers_found)
                    message += per_answer + "\n";

                chatDelegate("ChatBot", message.TrimEnd('\n'));
                chats.ScrollIntoView(chats.Items[chats.Items.Count - 1]);
            }
            else
            {
                string[] fallbackMessages =
                {
                    "I am sorry, I don't understand that. Could you try rephrasing your question?",
                    "I didn't quite get that. Try asking about a cybersecurity topic like passwords or phishing.",
                    "Hmm, I am not sure how to respond to that. Can you ask something else?",
                    "I couldn't find an answer for that. Please ask about security, privacy, or online safety.",
                    "My apologies, I don't have information on that topic yet."
                };

                Random random = new Random();
                chatDelegate("ChatBot", fallbackMessages[random.Next(fallbackMessages.Length)]);
            }

            question.Clear();
        }
        // end of ai_check


        // ── REMOVE SPECIAL CHARACTERS ──
        private string RemoveSpecialCharacters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            StringBuilder sanitized = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '\'' || c == '-')
                    sanitized.Append(c);
                else
                    sanitized.Append(' ');
            }

            string result = sanitized.ToString();
            result = Regex.Replace(result, @"\s+", " ").Trim();
            return result;
        }


        // ── AUTO SHOW INTEREST REMINDER (every 3 messages) ──
        private void auto_show_interest()
        {
            counting++;

            if (counting >= 3)
            {
                counting = 0;
                string filename = "interested_topic.txt";

                if (File.Exists(filename))
                {
                    string[] lines = File.ReadAllLines(filename);
                    foreach (string line in lines)
                    {
                        if (line.StartsWith(username))
                        {
                            int colonIndex = line.IndexOf("interested in:");
                            if (colonIndex >= 0)
                            {
                                string interests = line.Substring(colonIndex + 14).Trim();
                                chatDelegate("ChatBot",
                                    "By the way, as someone interested in " + interests +
                                    ", here is a related tip:");
                                ai_check(interests);
                            }
                            break;
                        }
                    }
                }
            }
        }


        // ── ERROR / CHAT DISPLAY METHOD ──
        private void error_method(string name, string message)
        {
            Border messageBorder = new Border
            {
                Margin = new Thickness(0, 2, 0, 2),
                Padding = new Thickness(5, 3, 5, 3),
                CornerRadius = new CornerRadius(5)
            };

            bool isBot = name.ToLower().Contains("chatbot") || name.ToLower().Contains("chat");

            if (isBot)
            {
                messageBorder.Background = new SolidColorBrush(Color.FromRgb(240, 248, 255));
                messageBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(173, 216, 230));
            }
            else
            {
                messageBorder.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
                messageBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(211, 211, 211));
            }
            messageBorder.BorderThickness = new Thickness(1);

            TextBlock messageText = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(2)
            };

            Brush nameColor = isBot ? Brushes.DarkBlue : Brushes.DarkGreen;
            Brush messageColor = Brushes.Black;

            messageText.Inlines.Add(new Run
            {
                Text = name + ": ",
                Foreground = nameColor,
                FontWeight = FontWeights.Bold
            });

            messageText.Inlines.Add(new Run
            {
                Text = message,
                Foreground = messageColor
            });

            messageBorder.Child = messageText;
            chats.Items.Add(messageBorder);
            chats.ScrollIntoView(chats.Items[chats.Items.Count - 1]);
        }// end of error_method


    }// end of class
}// end of namespace