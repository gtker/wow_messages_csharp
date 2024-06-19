using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_SEND_CALENDAR: WrathServerMessage, IWorldMessage {
    public required List<SendCalendarInvite> Invites { get; set; }
    public required List<SendCalendarEvent> Events { get; set; }
    public required uint CurrentTime { get; set; }
    public required uint ZoneTime { get; set; }
    public required List<SendCalendarInstance> Instances { get; set; }
    public required uint RelativeTime { get; set; }
    public required List<SendCalendarResetTime> ResetTimes { get; set; }
    public required uint AmountOfHolidays { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Invites.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Invites) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt((uint)Events.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Events) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(CurrentTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ZoneTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Instances.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Instances) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(RelativeTime, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)ResetTimes.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in ResetTimes) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteUInt(AmountOfHolidays, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1078, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 1078, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_SEND_CALENDAR> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        // ReSharper disable once UnusedVariable.Compiler
        var amountOfInvites = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var invites = new List<SendCalendarInvite>();
        for (var i = 0; i < amountOfInvites; ++i) {
            invites.Add(await Wrath.SendCalendarInvite.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfEvents = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var events = new List<SendCalendarEvent>();
        for (var i = 0; i < amountOfEvents; ++i) {
            events.Add(await Wrath.SendCalendarEvent.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        var currentTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var zoneTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfInstances = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var instances = new List<SendCalendarInstance>();
        for (var i = 0; i < amountOfInstances; ++i) {
            instances.Add(await Wrath.SendCalendarInstance.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        var relativeTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfResetTimes = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var resetTimes = new List<SendCalendarResetTime>();
        for (var i = 0; i < amountOfResetTimes; ++i) {
            resetTimes.Add(await Wrath.SendCalendarResetTime.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        var amountOfHolidays = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_SEND_CALENDAR {
            Invites = invites,
            Events = events,
            CurrentTime = currentTime,
            ZoneTime = zoneTime,
            Instances = instances,
            RelativeTime = relativeTime,
            ResetTimes = resetTimes,
            AmountOfHolidays = amountOfHolidays,
        };
    }

    internal int Size() {
        var size = 0;

        // amount_of_invites: Generator.Generated.DataTypeInteger
        size += 4;

        // invites: Generator.Generated.DataTypeArray
        size += Invites.Sum(e => e.Size());

        // amount_of_events: Generator.Generated.DataTypeInteger
        size += 4;

        // events: Generator.Generated.DataTypeArray
        size += Events.Sum(e => e.Size());

        // current_time: Generator.Generated.DataTypeInteger
        size += 4;

        // zone_time: Generator.Generated.DataTypeDateTime
        size += 4;

        // amount_of_instances: Generator.Generated.DataTypeInteger
        size += 4;

        // instances: Generator.Generated.DataTypeArray
        size += Instances.Sum(e => 20);

        // relative_time: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_reset_times: Generator.Generated.DataTypeInteger
        size += 4;

        // reset_times: Generator.Generated.DataTypeArray
        size += ResetTimes.Sum(e => 12);

        // amount_of_holidays: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

