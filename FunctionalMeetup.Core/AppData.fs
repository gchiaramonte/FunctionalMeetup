﻿namespace FunctionalMeetup

open System

[<Measure>]
type km

type Meetup =
    {
        Id : string
        Name : string
        Location : Location
        Invitations : (Person * InvitationStatus)[]
    }

and InvitationStatus = Accepted of Location | NotAccepted

and Person =
    {
        Id : string
        Name : string
    }

and Location =
    {
        Time : DateTimeOffset
        Latitude : float
        Longitude : float
    }
    static member ( - ) (x : Location, y : Location) =
        {
            TimeSpan = x.Time - y.Time
            Distance = 10.0<km> // TODO: Calc distance
        }

and LocationDelta =
    {
        TimeSpan : TimeSpan
        Distance : float<km>
    }
    member this.IsNear = this.TimeSpan.TotalMinutes < 5.0

type AppData =
    {
        User : Person
        AuthToken : string
        
        Settings : AppSettings
        
        Location : Location
        Friends : Person[]
        Meetups : Meetup[]
    }
    
and AppSettings =
    {
        ShareLocation : bool
    }    

