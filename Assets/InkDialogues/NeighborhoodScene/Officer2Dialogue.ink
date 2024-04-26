-> officer2start
=== officer2start
What's up? -> johnquestion
= johnquestion
* [How are you?]
    -> responses.how
* [What's the situation?]
    -> responses.situation
* [Where's my partner?]
    -> responses.partner
+ [Goodbye]
    Later.
    -> END

=== responses
= how
I’m doing fine, but, maybe focus on the case.
-> officer2start.johnquestion
= situation
Didn’t Joe just tell you that? The murderer got what he deserved. That’s it.
-> officer2start.johnquestion
= partner
He’s waiting for you at the crime scene. He’s been waiting for you to arrive before he’s touched anything. Might be a good idea to see him.
-> officer2start.johnquestion
