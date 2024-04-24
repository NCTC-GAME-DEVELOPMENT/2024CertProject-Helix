-> neighborstart
=== neighborstart
Can I help you officer?
* [What were you doing?]
    -> neighborquestions.do
* [What happened?]
    -> neighborquestions.happen
* [Did you see anybody?]
    -> neighborquestions.see
+ [Goodbye.]
    I’ll try to remember anything that might help.
    - Good night, mister.
        -> END
=== neighborquestions
= do
I woke up to a scream and I went downstairs to look out the window and I didn’t see anything, so I called the police.
* [You're the one who called?]
    Yes sir.
    * * [Good to know.]
        -> neighborstart
= happen
I don’t know, I didn’t see much but the body. I was too scared to investigate.”
* [Smart move, we don't want more dead people tonight.]
    -> neighborstart
= see
I saw a dark shadow move into the dark but nothing of detail.
    * [Damn, worth a shot.]
        -> neighborstart