using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using KeepCoding;
using System;
using RND = UnityEngine.Random;
using System.Text.RegularExpressions;

public class StellarScript : ModuleScript
{
    [SerializeField]
    private AnimationCurve _ease, brailleOut, brailleIn;
    [SerializeField]
    private new Transform transform;
    [SerializeField]
    private Material bright, dark, green, red;

    private readonly List<Quaternion> points = new List<Quaternion>();
    private readonly List<float> weights = new List<float>();

    const float multiplier = 1f;
    private float bonus = 0f;

    private static readonly string[] Passwords = "abs|aby|ace|act|ado|ads|adz|aft|age|ago|ags|ahi|ahs|aid|ail|aim|ain|air|ais|ait|aji|alb|ale|alp|als|alt|ami|amp|amu|and|ane|ani|ant|any|ape|apo|apt|arb|arc|are|arf|ark|arm|ars|art|ash|ask|asp|ate|auk|ave|avo|awe|awl|awn|axe|aye|ays|azo|bad|bag|bah|bal|bam|ban|bap|bar|bas|bat|bay|bed|beg|bel|ben|bes|bet|bey|bid|big|bin|bio|bis|bit|biz|boa|bod|bog|bop|bos|bot|bow|box|boy|bra|bro|bud|bug|bum|bun|bur|bus|but|buy|bye|bys|cab|cad|caf|cam|can|cap|car|cat|caw|cay|cel|cep|chi|cig|cis|cob|cod|cog|col|con|cop|cor|cos|cot|cow|cox|coy|coz|cru|cry|cub|cud|cue|cup|cur|cut|cuz|cwm|dab|dag|dah|dak|dal|dam|dan|dap|das|daw|day|deb|def|del|den|dep|dev|dew|dex|dey|dib|die|dif|dig|dim|din|dip|dis|dit|doc|doe|dog|doh|dol|dom|don|dor|dos|dot|dow|dry|dub|due|dug|duh|dui|dum|dun|duo|dup|dye|ear|eat|eau|eco|ecu|edh|eds|efs|eft|ego|eld|elf|elk|elm|els|emo|ems|emu|end|eng|ens|eon|era|erg|ern|ers|est|eta|eth|fab|fad|fah|fan|far|fas|fat|fax|fay|fed|feh|fem|fen|fer|fes|fet|feu|few|fey|fez|fib|fid|fie|fig|fil|fin|fir|fit|fix|fiz|flu|fly|fob|foe|fog|foh|fon|fop|for|fou|fox|foy|fro|fry|fub|fud|fug|fun|fur|gab|gad|gae|gal|gam|gan|gap|gar|gas|gat|gay|ged|gel|gem|gen|get|gey|ghi|gib|gid|gie|gif|gin|gip|gis|git|gnu|goa|gob|god|gor|gos|got|gox|gul|gum|gun|gut|guv|guy|gym|gyp|had|hae|hag|haj|ham|hao|hap|has|hat|haw|hay|hem|hen|hep|her|hes|het|hew|hex|hey|hic|hid|hie|him|hin|hip|his|hit|hob|hod|hoe|hog|hom|hon|hop|hot|how|hoy|hub|hue|hug|hum|hun|hup|hut|hyp|ice|ich|ick|icy|ids|ifs|ilk|imp|ink|ins|ion|ire|irk|ism|its|ivy|jab|jag|jam|jar|jaw|jay|jet|jeu|jib|jig|jin|job|joe|jog|jot|jow|joy|jug|jun|jus|jut|kab|kae|kaf|kas|kat|kay|kea|kef|keg|ken|kep|kex|key|khi|kid|kif|kin|kip|kir|kis|kit|koa|kob|koi|kop|kor|kos|kue|kye|lab|lac|lad|lag|lah|lam|lap|lar|las|lat|lav|law|lax|lay|lea|led|leg|lei|lek|let|leu|lev|lex|ley|lib|lid|lie|lin|lip|lis|lit|lob|log|lop|lot|low|lox|lud|lug|lum|lun|luv|lux|lye|mac|mad|mae|mag|man|map|mar|mas|mat|maw|max|may|med|meg|meh|mel|men|met|mew|mho|mib|mic|mid|mig|mil|mir|mis|mix|moa|mob|moc|mod|mog|moi|mol|mon|mop|mor|mos|mot|mow|mud|mug|mun|mus|mut|mux|myc|nab|nae|nag|nah|nam|nap|nav|naw|nay|neb|neg|net|new|nib|nil|nim|nip|nit|nix|nob|nod|nog|noh|nom|nor|nos|not|now|nth|nub|nug|nus|nut|oaf|oak|oar|oat|oba|obe|obi|oca|och|oda|ode|ods|oes|oft|ohm|ohs|oik|oil|oka|oke|old|ole|oma|oms|one|ons|opa|ope|ops|opt|ora|orb|orc|ore|org|ors|ort|ose|oud|our|out|ova|owe|owl|own|owt|oxy|pac|pad|pah|pak|pal|pam|pan|par|pas|pat|paw|pax|pay|pea|pec|ped|peg|peh|pen|per|pes|pet|pew|phi|pho|pht|pia|pic|pie|pig|pin|pis|pit|piu|pix|ply|pod|poh|poi|pol|pom|pos|pot|pow|pox|pro|pry|psi|pst|pub|pud|pug|pul|pun|pur|pus|put|pya|pye|pyx|qat|qis|qua|rad|rag|rah|rai|raj|ram|ran|rap|ras|rat|raw|rax|ray|reb|rec|red|ref|reg|rei|rem|rep|res|ret|rev|rex|rez|rho|ria|rib|rid|rif|rig|rim|rin|rip|rob|roc|rod|roe|rom|rot|row|rub|rue|rug|rum|run|rut|rya|rye|ryu|sab|sac|sad|sae|sag|sal|san|sap|sat|sau|saw|sax|say|sea|sec|seg|sei|sel|sen|ser|set|sev|sew|sex|sha|she|sho|shy|sib|sic|sig|sim|sin|sip|sir|sit|six|ska|ski|sky|sly|sob|soc|sod|soh|sol|som|son|sop|sot|sou|sow|sox|soy|spa|spy|sri|sty|sub|sue|suk|sum|sun|sup|suq|syn|tab|tad|tae|tag|taj|tam|tan|tao|tap|tar|tas|tau|tav|taw|tax|tea|tec|ted|teg|tel|ten|tes|tew|the|tho|thy|tic|tie|til|tin|tip|tis|tix|tiz|tod|toe|tog|tom|ton|top|tor|tow|toy|try|tsk|tub|tug|tui|tum|tun|tup|tux|twa|two|tye|udo|ugh|uke|ump|ums|uni|uns|upo|ups|urb|urd|urn|urp|use|uta|ute|uts|vac|van|var|vas|vat|vau|vaw|veg|vet|vex|via|vid|vie|vig|vim|vin|vis|voe|vog|vow|vox|vug|vum|wab|wad|wae|wag|wan|wap|war|was|wat|wax|way|web|wed|wen|wet|wha|who|why|wig|win|wis|wit|wiz|woe|wok|won|wos|wot|wry|wud|wye|wyn|xis|yag|yah|yak|yam|yap|yar|yas|yaw|yea|yeh|yen|yep|yes|yet|yew|yin|yip|yob|yod|yok|yom|yon|you|yow|yuk|yum|yup|zag|zap|zas|zax|zed|zek|zen|zep|zig|zin|zip|zit|zoa".Split("|");

    private void Start()
    {
        points.Add(RND.rotation);
        weights.Add(0f);
        points.Add(RND.rotation);
        weights.Add(0.5f);

        Get<KMSelectable>().Children[0].OnInteract += () => { Push(); Get<KMSelectable>().AddInteractionPunch(1f); return false; };
        Get<KMSelectable>().Children[0].OnInteractEnded += () => { PushOff(); };
    }

    private void FixedUpdate()
    {
        Quaternion calc = transform.localRotation;
        List<int> toRemove = new List<int>();
        for(int i = 0; i < points.Count; i++)
        {
            calc = Quaternion.Lerp(calc, points[i], _ease.Evaluate(weights[i]));
            weights[i] += (multiplier + bonus) * Time.fixedDeltaTime;
            if(weights[i] > 1f)
                toRemove.Add(i);
        }
        foreach(int i in toRemove.OrderByDescending(c => c))
        {
            weights.RemoveAt(i);
            points.RemoveAt(i);
        }

        transform.localRotation = calc;

        if(weights.Count < 2)
        {
            points.Add(RND.rotation);
            weights.Add(0f);
        }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + bonus, transform.localEulerAngles.z);

        bonus -= 3 * Time.fixedDeltaTime;
        if(bonus < 0f)
            bonus = 0f;
    }

    private float _pushTime = 0f;
    private Coroutine pulse = null;

    private void Push()
    {
        bonus += 2f;
        if(IsSolved)
            return;
        _pushTime = Time.time;
        pulse = StartCoroutine(Pulse());
    }

    private IEnumerator Pulse()
    {
        while(true)
        {
            yield return new WaitForSeconds(.9f);
            transform.GetComponent<MeshRenderer>().material = bright;
            yield return new WaitForSeconds(.1f);
            transform.GetComponent<MeshRenderer>().material = dark;
        }
    }

    private void PushOff()
    {
        bonus += 2f;
        if(IsSolved)
            return;
        StopCoroutine(pulse);
        if(Time.time - _pushTime < 1f)
        {
            StartCoroutine(PlayCodes());
        }
        else
        {
            Submit(Mathf.FloorToInt(Time.time - _pushTime));
        }
    }

    const string alph = "abcdefghijklmnopqrstuvwxyz";

    private void Submit(int time)
    {
        if(lastPlayed == "---")
        {
            Strike("That was incorrect, you didn't even see what I had to say. You have struck.");
            StartCoroutine(Red());
            return;
        }
        int ans = (alph.IndexOf(lastPlayed[0]) + 1 + alph.IndexOf(lastPlayed[1]) + 1 + alph.IndexOf(lastPlayed[2]) + 1) % 10 + 2;
        if(time == ans)
        {
            transform.GetComponent<MeshRenderer>().material = green;
            PlaySound("Solve");
            Solve("Good job, that was correct.");
        }
        else
        {
            Strike("That was incorrect, you should have submitted {0} but you sumitted {1}. You have struck.".Form(ans, time));
            StartCoroutine(Red());
        }
    }

    private IEnumerator Red()
    {
        transform.GetComponent<MeshRenderer>().material = red;
        yield return new WaitForSeconds(.7f);
        transform.GetComponent<MeshRenderer>().material = dark;
    }

    private static readonly Dictionary<char, bool[]> Braille = "abcdefghijklmnopqrstuvwxyz".ToDictionary(c => c, c =>
    {
        const bool Y = true;
        const bool U = false;
        switch(c)
        {
            case 'a':
                return new[] { Y, U, U, U, U, U };
            case 'b':
                return new[] { Y, Y, U, U, U, U };
            case 'c':
                return new[] { Y, U, U, Y, U, U };
            case 'd':
                return new[] { Y, U, U, Y, Y, U };
            case 'e':
                return new[] { Y, U, U, U, Y, U };
            case 'f':
                return new[] { Y, Y, U, Y, U, U };
            case 'g':
                return new[] { Y, Y, U, Y, Y, U };
            case 'h':
                return new[] { Y, Y, U, U, Y, U };
            case 'i':
                return new[] { U, Y, U, Y, U, U };
            case 'j':
                return new[] { U, Y, U, Y, Y, U };
            case 'k':
                return new[] { Y, U, Y, U, U, U };
            case 'l':
                return new[] { Y, Y, Y, U, U, U };
            case 'm':
                return new[] { Y, U, Y, Y, U, U };
            case 'n':
                return new[] { Y, U, Y, Y, Y, U };
            case 'o':
                return new[] { Y, U, Y, U, Y, U };
            case 'p':
                return new[] { Y, Y, Y, Y, U, U };
            case 'q':
                return new[] { Y, Y, Y, Y, Y, U };
            case 'r':
                return new[] { Y, Y, Y, U, Y, U };
            case 's':
                return new[] { U, Y, Y, Y, U, U };
            case 't':
                return new[] { U, Y, Y, Y, Y, U };
            case 'u':
                return new[] { Y, U, Y, U, U, Y };
            case 'v':
                return new[] { Y, Y, Y, U, U, Y };
            case 'w':
                return new[] { U, Y, U, Y, Y, Y };
            case 'x':
                return new[] { Y, U, Y, Y, U, Y };
            case 'y':
                return new[] { Y, U, Y, Y, Y, Y };
            case 'z':
                return new[] { Y, U, Y, U, Y, Y };
        }
        return new bool[6];
    });
    private static readonly Dictionary<char, bool[]> MorseCode = "abcdefghijklmnopqrstuvwxyz".ToDictionary(c => c, c =>
    {
        const bool Y = true;
        const bool U = false;
        switch(c)
        {
            case 'a':
                return new[] { Y, U, Y, Y, Y };
            case 'b':
                return new[] { Y, Y, Y, U, Y, U, Y, U, Y };
            case 'c':
                return new[] { Y, Y, Y, U, Y, Y, Y, U, Y, U, Y };
            case 'd':
                return new[] { Y, Y, Y, U, Y, U, Y };
            case 'e':
                return new[] { Y };
            case 'f':
                return new[] { Y, U, Y, U, Y, Y, Y, U, Y };
            case 'g':
                return new[] { Y, Y, Y, U, Y, Y, Y, U, Y };
            case 'h':
                return new[] { Y, U, Y, U, Y, U, Y };
            case 'i':
                return new[] { Y, U, Y };
            case 'j':
                return new[] { Y, U, Y, Y, Y, U, Y, Y, Y, U, Y, Y, Y };
            case 'k':
                return new[] { Y, Y, Y, U, Y, U, Y, Y, Y };
            case 'l':
                return new[] { Y, U, Y, Y, Y, U, Y, U, Y };
            case 'm':
                return new[] { Y, Y, Y, U, Y, Y, Y };
            case 'n':
                return new[] { Y, Y, Y, U, Y };
            case 'o':
                return new[] { Y, Y, Y, U, Y, Y, Y, U, Y, Y, Y };
            case 'p':
                return new[] { Y, U, Y, Y, Y, U, Y, Y, Y, U, Y };
            case 'q':
                return new[] { Y, Y, Y, U, Y, Y, Y, U, Y, U, Y, Y, Y };
            case 'r':
                return new[] { Y, U, Y, Y, Y, U, Y };
            case 's':
                return new[] { Y, U, Y, U, Y };
            case 't':
                return new[] { Y, Y, Y };
            case 'u':
                return new[] { Y, U, Y, U, Y, Y, Y };
            case 'v':
                return new[] { Y, U, Y, U, Y, U, Y, Y, Y };
            case 'w':
                return new[] { Y, U, Y, Y, Y, U, Y, Y, Y };
            case 'x':
                return new[] { Y, Y, Y, U, Y, U, Y, U, Y, Y, Y };
            case 'y':
                return new[] { Y, Y, Y, U, Y, U, Y, Y, Y, U, Y, Y, Y };
            case 'z':
                return new[] { Y, Y, Y, U, Y, Y, Y, U, Y, U, Y };
        }
        return new bool[6];
    });
    private static readonly Dictionary<char, int[]> TapCode = "abcdefghijklmnopqrstuvwxyz".ToDictionary(c => c, c =>
    {
        switch(c)
        {
            case 'a':
                return new[] { 1, 1 };
            case 'b':
                return new[] { 1, 2 };
            case 'c':
                return new[] { 1, 3 };
            case 'd':
                return new[] { 1, 4 };
            case 'e':
                return new[] { 1, 5 };
            case 'f':
                return new[] { 2, 1 };
            case 'g':
                return new[] { 2, 2 };
            case 'h':
                return new[] { 2, 3 };
            case 'i':
                return new[] { 2, 4 };
            case 'j':
                return new[] { 2, 5 };
            case 'k':
                return new[] { 1, 3 };
            case 'l':
                return new[] { 3, 1 };
            case 'm':
                return new[] { 3, 2 };
            case 'n':
                return new[] { 3, 3 };
            case 'o':
                return new[] { 3, 4 };
            case 'p':
                return new[] { 3, 5 };
            case 'q':
                return new[] { 4, 1 };
            case 'r':
                return new[] { 4, 2 };
            case 's':
                return new[] { 4, 3 };
            case 't':
                return new[] { 4, 4 };
            case 'u':
                return new[] { 4, 5 };
            case 'v':
                return new[] { 5, 1 };
            case 'w':
                return new[] { 5, 2 };
            case 'x':
                return new[] { 5, 3 };
            case 'y':
                return new[] { 5, 4 };
            case 'z':
                return new[] { 5, 5 };
        }
        return new int[2];
    });
    private const float Delay = 1f;
    private string lastPlayed = "---";
    private int playedCount = 0;
    private bool playing;

    private IEnumerator PlayCodes()
    {
        if(playing)
            yield break;
        playing = true;
        if(lastPlayed == "---" || playedCount >= 2)
        {
            lastPlayed = Passwords.PickRandom();
            playedCount = 0;
        }
        Log("You asked me to play a word, and I chose \"{0}\".".Form(lastPlayed));
        StartCoroutine(PlayTapCode(lastPlayed[1]));
        StartCoroutine(PlayMorseCode(lastPlayed[2]));
        float time = 0f;
        foreach(bool b in Braille[lastPlayed[0]])
        {
            while(time < Delay)
            {
                time += Time.deltaTime;
                if(b)
                    transform.localScale = new Vector3(.3f, .3f, .3f) * brailleOut.Evaluate(time / Delay);
                else
                    transform.localScale = new Vector3(.3f, .3f, .3f) * brailleIn.Evaluate(time / Delay); ;
                yield return null;
            }
            time = 0f;
        }
        transform.localScale = new Vector3(.3f, .3f, .3f);
        playedCount++;
        playing = false;
    }

    private IEnumerator PlayMorseCode(char p)
    {
        bool[] play = MorseCode[p].Concat(Enumerable.Repeat(false, 12)).ToArray();
        for(int i = 0; i < 13; i++)
        {
            if(play[i])
            {
                transform.GetComponent<MeshRenderer>().material = bright;
            }
            else
            {
                transform.GetComponent<MeshRenderer>().material = dark;
            }
            yield return new WaitForSeconds(Delay * 6f / 13f);
        }
        transform.GetComponent<MeshRenderer>().material = dark;
    }

    private IEnumerator PlayTapCode(char p)
    {
        float time = Time.time;
        for(int i = 0; i < TapCode[p][0]; i++)
        {
            PlaySound("TPCD");
            yield return new WaitForSeconds(Delay * 2.5f / TapCode[p][0]);
        }
        while(time < Delay * 3f)
            yield return null;
        for(int i = 0; i < TapCode[p][1]; i++)
        {
            PlaySound("TPCD2");
            yield return new WaitForSeconds(Delay * 2.5f / TapCode[p][1]);
        }
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use '!{0} tap' to tap the module. Use '!{0} hold 3' to hold the module for 3 pulses.";
#pragma warning restore 414

    private IEnumerator ProcessTwitchCommand(string command)
    {
        Match m;
        if(Regex.IsMatch(command.Trim().ToLowerInvariant(), "tap"))
        {
            yield return null;
            Get<KMSelectable>().Children[0].OnInteract();
            Get<KMSelectable>().Children[0].OnInteractEnded();
        }
        else if ((m = Regex.Match(command.Trim().ToLowerInvariant(), "hold (\\d{1,2})")).Success)
        {
            int c;
            if(!int.TryParse(m.Groups[1].Value, out c))
                yield break;
            if(c > 11)
                yield break;
            yield return null;
            Get<KMSelectable>().Children[0].OnInteract();
            yield return new WaitForSeconds(0.5f + c);
            Get<KMSelectable>().Children[0].OnInteractEnded();
        }
        else
            yield break;
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        Get<KMSelectable>().Children[0].OnInteract();
        Get<KMSelectable>().Children[0].OnInteractEnded();
        while(playing)
            yield return true;
        int ans = (alph.IndexOf(lastPlayed[0]) + 1 + alph.IndexOf(lastPlayed[1]) + 1 + alph.IndexOf(lastPlayed[2]) + 1) % 10 + 2;
        Get<KMSelectable>().Children[0].OnInteract();
        yield return new WaitForSeconds(ans + 0.5f);
        Get<KMSelectable>().Children[0].OnInteractEnded();
    }
}
