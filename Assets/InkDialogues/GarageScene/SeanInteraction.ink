VAR sean_is_ok = false

-> sean
=== sean
What's up?
* {!sean_is_ok}[How are you?]
    -> how
* {sean_is_ok}[You sure you're ok?]
    -> thing.ok
* [What happened?]
    -> thing.happen
+ [Goodbye.]
    -> thing.goodbye

=== how
Not great, the divorce has taken a toll on me.
She’s taking the kids, man. I don’t know what to do.
I’ve tried to go to marriage counseling but her issue was me being out so late. But she doesn’t under—
    * [This is your life.]
       Exactly. My family’s been in law enforcement for 4 generations now, and I’ve always wanted to follow their footsteps.
        * * [You don’t have to.]
            * * * [You know that, right?]
                I gotta prove to my father that I can be worth more than a punching bag.
            -> dig
= dig
* [You sure you're ok?]
    Yes. Let's find this guy.
    ~ sean_is_ok = true
    -> sean
=== thing
= ok
I'm fine, let's change the subject, please.
-> sean
= happen
I think the killer opened the garage from the outside and grabbed the saw.
After breaking through the door,
<> the killer stalked the house until either the girl ran out or some fight happened,
<> but we know they ended up out here.
* [Regarding forensics...?]
    I’ll let you know when we find out.
    * * [Good hypothesis so far.]
            -> sean
= goodbye
See you at the station, man.
-> END