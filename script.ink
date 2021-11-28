LIST room = lobby, coven_room, bathroom

Welcome to the blueprint of the real.
-> room_lobby

== rooms == 
    + { room != lobby } [move:lobby] -> room_lobby 
    + { room != coven_room } [move:coven_room] -> room_coven 
    + { room != bathroom } [move:bathroom] -> room_bathroom 

== room_lobby ==
    #move lobby
    ~ room = lobby 
    You {begin in|return to} the lobby.
    -> rooms

== room_coven ==
    #move coven_room
    ~ room = coven_room
    -> leave
    = leave
    You enter the coven room. <> { not stay:
        It's scary in here. Do you want to leave immediately?
        + [I do.] -> room_lobby # move lobby
        + [I don't.] -> stay
    - else: -> stay
    }
    = stay
    -> rooms

== room_bathroom ==
    #move bathroom
    ~ room = bathroom
    You enter the bathroom.
    - (act)
    <- actions
    <- rooms
    -> DONE
= actions
    * [Take shower.] You feel clean.
    * [Wash hands.] You feel morally clean.
    - -> act