-> room_lobby

== rooms == 
+ [Lobby] -> room_lobby #move lobby
+ [Coven Room] -> room_coven #move coven room

== room_lobby ==
You {begin in|return to} the lobby.
-> rooms

== room_coven ==
= leave
You enter the coven room. <> { not stay:
    It's scary in here. Do you want to leave immediately?
    + [I do.] -> room_lobby # move lobby
    + [I don't.] -> stay
- else: -> stay
}
= stay
-> rooms