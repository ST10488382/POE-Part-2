using System.Collections;

namespace poepart2
{
    public class respond
    {
        public respond(ArrayList reply, ArrayList ignore)
        {//start of constructor

            answers(reply);
            words(ignore);

        }//end of constructor

        //method to store the list of stop-words to ignore
        private void words(ArrayList ignoring)
        {
            ignoring.Add("a");
            ignoring.Add("about");
            ignoring.Add("above");
            ignoring.Add("across");
            ignoring.Add("after");
            ignoring.Add("afterwards");
            ignoring.Add("again");
            ignoring.Add("against");
            ignoring.Add("all");
            ignoring.Add("almost");
            ignoring.Add("alone");
            ignoring.Add("along");
            ignoring.Add("already");
            ignoring.Add("also");
            ignoring.Add("although");
            ignoring.Add("always");
            ignoring.Add("am");
            ignoring.Add("among");
            ignoring.Add("amongst");
            ignoring.Add("amount");
            ignoring.Add("an");
            ignoring.Add("and");
            ignoring.Add("another");
            ignoring.Add("any");
            ignoring.Add("anyhow");
            ignoring.Add("anyone");
            ignoring.Add("anything");
            ignoring.Add("anyway");
            ignoring.Add("anywhere");
            ignoring.Add("are");
            ignoring.Add("around");
            ignoring.Add("as");
            ignoring.Add("at");
            ignoring.Add("back");
            ignoring.Add("be");
            ignoring.Add("became");
            ignoring.Add("because");
            ignoring.Add("become");
            ignoring.Add("becomes");
            ignoring.Add("becoming");
            ignoring.Add("been");
            ignoring.Add("before");
            ignoring.Add("beforehand");
            ignoring.Add("behind");
            ignoring.Add("being");
            ignoring.Add("below");
            ignoring.Add("beside");
            ignoring.Add("besides");
            ignoring.Add("between");
            ignoring.Add("beyond");
            ignoring.Add("both");
            ignoring.Add("but");
            ignoring.Add("by");
            ignoring.Add("can");
            ignoring.Add("cannot");
            ignoring.Add("could");
            ignoring.Add("did");
            ignoring.Add("do");
            ignoring.Add("does");
            ignoring.Add("doing");
            ignoring.Add("done");
            ignoring.Add("down");
            ignoring.Add("during");
            ignoring.Add("each");
            ignoring.Add("either");
            ignoring.Add("else");
            ignoring.Add("elsewhere");
            ignoring.Add("enough");
            ignoring.Add("etc");
            ignoring.Add("even");
            ignoring.Add("ever");
            ignoring.Add("every");
            ignoring.Add("everyone");
            ignoring.Add("everything");
            ignoring.Add("everywhere");
            ignoring.Add("except");
            ignoring.Add("few");
            ignoring.Add("first");
            ignoring.Add("for");
            ignoring.Add("former");
            ignoring.Add("formerly");
            ignoring.Add("from");
            ignoring.Add("further");
            ignoring.Add("had");
            ignoring.Add("has");
            ignoring.Add("have");
            ignoring.Add("having");
            ignoring.Add("he");
            ignoring.Add("hence");
            ignoring.Add("her");
            ignoring.Add("here");
            ignoring.Add("hereafter");
            ignoring.Add("hereby");
            ignoring.Add("herein");
            ignoring.Add("hereupon");
            ignoring.Add("hers");
            ignoring.Add("herself");
            ignoring.Add("him");
            ignoring.Add("himself");
            ignoring.Add("his");
            ignoring.Add("how");
            ignoring.Add("however");
            ignoring.Add("i");
            ignoring.Add("if");
            ignoring.Add("in");
            ignoring.Add("indeed");
            ignoring.Add("inside");
            ignoring.Add("instead");
            ignoring.Add("into");
            ignoring.Add("is");
            ignoring.Add("it");
            ignoring.Add("its");
            ignoring.Add("itself");
            ignoring.Add("last");
            ignoring.Add("later");
            ignoring.Add("latter");
            ignoring.Add("latterly");
            ignoring.Add("least");
            ignoring.Add("less");
            ignoring.Add("lot");
            ignoring.Add("many");
            ignoring.Add("may");
            ignoring.Add("me");
            ignoring.Add("meanwhile");
            ignoring.Add("might");
            ignoring.Add("more");
            ignoring.Add("moreover");
            ignoring.Add("most");
            ignoring.Add("mostly");
            ignoring.Add("much");
            ignoring.Add("must");
            ignoring.Add("my");
            ignoring.Add("myself");
            ignoring.Add("name");
            ignoring.Add("namely");
            ignoring.Add("neither");
            ignoring.Add("never");
            ignoring.Add("nevertheless");
            ignoring.Add("next");
            ignoring.Add("no");
            ignoring.Add("nobody");
            ignoring.Add("none");
            ignoring.Add("noone");
            ignoring.Add("nor");
            ignoring.Add("not");
            ignoring.Add("nothing");
            ignoring.Add("now");
            ignoring.Add("nowhere");
            ignoring.Add("of");
            ignoring.Add("off");
            ignoring.Add("often");
            ignoring.Add("on");
            ignoring.Add("once");
            ignoring.Add("one");
            ignoring.Add("only");
            ignoring.Add("or");
            ignoring.Add("other");
            ignoring.Add("others");
            ignoring.Add("otherwise");
            ignoring.Add("ought");
            ignoring.Add("our");
            ignoring.Add("ours");
            ignoring.Add("ourselves");
            ignoring.Add("out");
            ignoring.Add("outside");
            ignoring.Add("over");
            ignoring.Add("own");
            ignoring.Add("part");
            ignoring.Add("per");
            ignoring.Add("perhaps");
            ignoring.Add("please");
            ignoring.Add("put");
            ignoring.Add("rather");
            ignoring.Add("re");
            ignoring.Add("same");
            ignoring.Add("see");
            ignoring.Add("seem");
            ignoring.Add("seemed");
            ignoring.Add("seeming");
            ignoring.Add("seems");
            ignoring.Add("several");
            ignoring.Add("she");
            ignoring.Add("should");
            ignoring.Add("show");
            ignoring.Add("side");
            ignoring.Add("since");
            ignoring.Add("so");
            ignoring.Add("some");
            ignoring.Add("somehow");
            ignoring.Add("someone");
            ignoring.Add("something");
            ignoring.Add("sometime");
            ignoring.Add("sometimes");
            ignoring.Add("somewhere");
            ignoring.Add("still");
            ignoring.Add("such");
            ignoring.Add("take");
            ignoring.Add("than");
            ignoring.Add("that");
            ignoring.Add("the");
            ignoring.Add("their");
            ignoring.Add("theirs");
            ignoring.Add("them");
            ignoring.Add("themselves");
            ignoring.Add("then");
            ignoring.Add("thence");
            ignoring.Add("there");
            ignoring.Add("thereafter");
            ignoring.Add("thereby");
            ignoring.Add("therefore");
            ignoring.Add("therein");
            ignoring.Add("thereupon");
            ignoring.Add("these");
            ignoring.Add("they");
            ignoring.Add("this");
            ignoring.Add("those");
            ignoring.Add("though");
            ignoring.Add("through");
            ignoring.Add("throughout");
            ignoring.Add("thru");
            ignoring.Add("thus");
            ignoring.Add("to");
            ignoring.Add("together");
            ignoring.Add("too");
            ignoring.Add("toward");
            ignoring.Add("towards");
            ignoring.Add("under");
            ignoring.Add("unless");
            ignoring.Add("until");
            ignoring.Add("up");
            ignoring.Add("upon");
            ignoring.Add("us");
            ignoring.Add("used");
            ignoring.Add("very");
            ignoring.Add("via");
            ignoring.Add("was");
            ignoring.Add("we");
            ignoring.Add("well");
            ignoring.Add("were");
            ignoring.Add("what");
            ignoring.Add("whatever");
            ignoring.Add("when");
            ignoring.Add("whence");
            ignoring.Add("whenever");
            ignoring.Add("where");
            ignoring.Add("whereafter");
            ignoring.Add("whereas");
            ignoring.Add("whereby");
            ignoring.Add("wherein");
            ignoring.Add("whereupon");
            ignoring.Add("wherever");
            ignoring.Add("whether");
            ignoring.Add("which");
            ignoring.Add("while");
            ignoring.Add("whither");
            ignoring.Add("who");
            ignoring.Add("whoever");
            ignoring.Add("whole");
            ignoring.Add("whom");
            ignoring.Add("whose");
            ignoring.Add("why");
            ignoring.Add("will");
            ignoring.Add("with");
            ignoring.Add("within");
            ignoring.Add("without");
            ignoring.Add("would");
            ignoring.Add("yes");
            ignoring.Add("yet");
            ignoring.Add("hey");
            ignoring.Add("you");
            ignoring.Add("your");
            ignoring.Add("yours");
            ignoring.Add("yourself");
            ignoring.Add("yourselves");
        }//end of words method


        public void answers(ArrayList add_answers)
        {//start of answers method

            // ── GREETINGS ──
            add_answers.Add("greeting i'm doing well, thanks for asking! how are you doing today?");
            add_answers.Add("greeting i'm great today, thanks for asking! how can i help you today?");
            add_answers.Add("greeting doing good today! hope you are also doing well today?");
            add_answers.Add("hello i'm doing well, thanks! how can i help you with cybersecurity today?");
            add_answers.Add("hello great to see you! ask me anything about staying safe online.");
            add_answers.Add("hi hello there! i'm your cybersecurity assistant. what would you like to know?");

            // ── PURPOSE ──
            add_answers.Add("purpose my purpose is to educate you on how to stay safe online and guide your cybersecurity questions.");
            add_answers.Add("purpose i help users understand online safety and digital protection.");
            add_answers.Add("purpose i assist with cybersecurity awareness and safety guidance.");

            // ── CYBERSECURITY (general) ──
            add_answers.Add("cybersecurity cybersecurity is about protecting systems and networks from digital threats.");
            add_answers.Add("cybersecurity it involves protecting devices and online accounts from attacks.");
            add_answers.Add("cybersecurity it focuses on securing digital information and systems from unauthorised access.");

            // ── PHISHING ──
            add_answers.Add("phishing phishing is a scam where attackers pretend to be trusted sources to steal your information.");
            add_answers.Add("phishing be cautious of emails asking for personal information — scammers often disguise themselves as trusted organisations.");
            add_answers.Add("phishing always check the sender's email address carefully before clicking any links.");
            add_answers.Add("phishing never click suspicious links in emails or text messages — go directly to the official website instead.");
            add_answers.Add("phishing if an email creates urgency or pressure, it is likely a phishing attempt.");

            // ── PASSWORD ──
            add_answers.Add("password a strong password uses a mix of uppercase, lowercase, numbers and symbols.");
            add_answers.Add("password it should be at least 12 characters long and not easy to guess.");
            add_answers.Add("password avoid using personal details like your name or birthday when creating a password.");
            add_answers.Add("password use a different password for every account to limit damage if one is compromised.");
            add_answers.Add("password consider using a reputable password manager to keep track of all your passwords safely.");

            // ── SCAM ──
            add_answers.Add("scam scammers often create a sense of urgency to pressure you into acting quickly — take your time.");
            add_answers.Add("scam if something sounds too good to be true online, it usually is a scam.");
            add_answers.Add("scam never send money or personal details to someone you have not verified independently.");
            add_answers.Add("scam report any suspected scam to your local cybercrime unit or consumer protection authority.");
            add_answers.Add("scam always verify the identity of anyone requesting sensitive information before responding.");

            // ── PRIVACY ──
            add_answers.Add("privacy review the privacy settings on your social media accounts regularly to control who sees your data.");
            add_answers.Add("privacy avoid sharing sensitive personal information such as your ID number or address on public platforms.");
            add_answers.Add("privacy read the privacy policy of apps before granting them access to your data.");
            add_answers.Add("privacy use private browsing mode when accessing sensitive accounts on shared devices.");
            add_answers.Add("privacy limit the personal information you post online — once it is shared, it is hard to remove.");

            // ── FIREWALL ──
            add_answers.Add("firewall a firewall controls network traffic based on security rules.");
            add_answers.Add("firewall it helps block unwanted access to your device or network.");
            add_answers.Add("firewall it acts as a protective barrier between trusted and untrusted networks.");

            // ── HACKED ACCOUNT ──
            add_answers.Add("hacked immediately change your password and log out of all devices if your account is compromised.");
            add_answers.Add("hacked contact the platform's support team straight away to report the breach.");
            add_answers.Add("hacked enable two-factor authentication to add an extra layer of security after being hacked.");
            add_answers.Add("account if you suspect your account is hacked, check recent login activity and revoke unknown sessions.");
            add_answers.Add("account secure your recovery email and phone number to prevent further unauthorised access.");

            // ── FRAUD ──
            add_answers.Add("fraud contact your bank immediately if you notice any unauthorised transactions.");
            add_answers.Add("fraud report suspicious financial activity to the relevant authorities without delay.");
            add_answers.Add("fraud monitor your bank statements regularly for any unusual activity.");

            // ── MALWARE / VIRUS ──
            add_answers.Add("malware malware is malicious software designed to damage or gain unauthorised access to your device.");
            add_answers.Add("malware always keep your antivirus software updated to detect and remove threats.");
            add_answers.Add("malware avoid downloading software from untrusted or unofficial sources.");
            add_answers.Add("virus run a full antivirus scan immediately if you suspect your device is infected.");
            add_answers.Add("virus never open email attachments from unknown senders as they may contain viruses.");

            // ── VPN ──
            add_answers.Add("vpn a vpn helps protect your privacy when using public wi-fi networks.");
            add_answers.Add("vpn it encrypts your internet traffic so others cannot intercept your data.");
            add_answers.Add("vpn using a vpn is especially important when accessing sensitive accounts on public networks.");

            // ── TWO-FACTOR AUTHENTICATION ──
            add_answers.Add("two-factor two-factor authentication adds a second verification step beyond just your password.");
            add_answers.Add("authentication enable two-factor authentication on all important accounts for stronger protection.");
            add_answers.Add("authentication even if someone steals your password, two-factor authentication can stop them from logging in.");

            // ── ENCRYPTION ──
            add_answers.Add("encryption encryption converts your data into a coded format that only authorised parties can read.");
            add_answers.Add("encryption always use websites that start with https — the 's' means the connection is encrypted.");
            add_answers.Add("encryption encrypted messaging apps protect your private conversations from being intercepted.");

            // ── SOCIAL ENGINEERING ──
            add_answers.Add("social social engineering manipulates people into revealing confidential information.");
            add_answers.Add("social attackers use trust and deception rather than technical hacks to gain access.");
            add_answers.Add("engineering be suspicious of anyone — even someone claiming to be IT support — asking for your login details.");

            // ── SAFE BROWSING ──
            add_answers.Add("browsing only visit websites you trust and look for the padlock icon in the browser address bar.");
            add_answers.Add("browsing avoid clicking on pop-up ads as they may redirect you to malicious sites.");
            add_answers.Add("safe keep your browser updated to benefit from the latest security patches.");

            // ── BACKUP ──
            add_answers.Add("backup regularly back up your important files to an external drive or secure cloud service.");
            add_answers.Add("backup a backup ensures you can recover your data if your device is lost or hit by ransomware.");
            add_answers.Add("backup test your backups occasionally to make sure they can be restored successfully.");

            // ── RANSOMWARE ──
            add_answers.Add("ransomware ransomware locks your files and demands payment for their release — never pay the ransom.");
            add_answers.Add("ransomware keep all software updated to close vulnerabilities that ransomware exploits.");
            add_answers.Add("ransomware regular offline backups are your best defence against a ransomware attack.");

            // ── MALICIOUS CHATBOT ──
            add_answers.Add("malicious malicious bots often create a sense of urgency to trick users into sharing personal data.");
            add_answers.Add("malicious fake chatbots may ask for sensitive information such as passwords or banking details.");
            add_answers.Add("malicious be cautious if any bot pressures you for personal data — a legitimate service will never do this.");

            // ── SENTIMENT DETECTION ──

            // Worried / Concerned
            add_answers.Add("worried it is completely understandable to feel that way. let me share some tips to help you stay safe.");
            add_answers.Add("worried do not panic — most cybersecurity issues can be resolved quickly with the right steps.");
            add_answers.Add("worried i understand your concern. together we can make sure your information stays protected.");
            add_answers.Add("concerned i hear you — being concerned about your online safety shows good awareness.");
            add_answers.Add("concerned let us work through this together. staying informed is the first step to staying safe.");

            // Curious
            add_answers.Add("curious great question! curiosity is the first step towards better cybersecurity awareness.");
            add_answers.Add("curious i love that you want to learn more. ask me anything about staying safe online.");
            add_answers.Add("curious exploring cybersecurity is a smart move. let me know what topic interests you most.");

            // Frustrated
            add_answers.Add("frustrated i understand you are frustrated. let us work through the issue step by step.");
            add_answers.Add("frustrated it is okay to feel frustrated when things are not working. i am here to help.");
            add_answers.Add("frustrated take a breath — we will sort this out together.");

            // Confused
            add_answers.Add("confused that is perfectly okay — cybersecurity can feel overwhelming at first. i will explain it clearly.");
            add_answers.Add("confused let me break it down step by step so it makes more sense.");
            add_answers.Add("confused no worries at all — i am here to help you understand it better.");

            // Happy / Excited
            add_answers.Add("happy that is great to hear! i am glad things are going well for you.");
            add_answers.Add("happy awesome! positivity is always good — now let us keep you just as safe online.");
            add_answers.Add("happy i am happy for you! let me know if you need anything.");
            add_answers.Add("excited that enthusiasm is great! let us channel it into learning some useful cybersecurity tips.");

            // Sad
            add_answers.Add("sad i am sorry you are feeling this way. i am here for you.");
            add_answers.Add("sad that sounds tough. take things one step at a time — you are not alone.");
            add_answers.Add("sad i hope things improve soon. you can talk to me anytime.");

            // Angry
            add_answers.Add("angry i understand you are angry. let us try to solve the issue together calmly.");
            add_answers.Add("angry it is okay to feel angry, but i will help you fix the problem.");
            add_answers.Add("angry take your time — i am here to help you sort it out.");

            // Scared / Afraid
            add_answers.Add("scared it is natural to feel scared about online threats. knowing what to look for is half the battle.");
            add_answers.Add("scared do not worry — i will walk you through the steps to protect yourself.");
            add_answers.Add("afraid being afraid is understandable, but you can take control of your online safety right now.");

            // Overwhelmed
            add_answers.Add("overwhelmed cybersecurity can feel like a lot at first. let us start with one simple step at a time.");
            add_answers.Add("overwhelmed you do not need to know everything at once — i am here to guide you through it gradually.");

        }//end of answers method

    }
}