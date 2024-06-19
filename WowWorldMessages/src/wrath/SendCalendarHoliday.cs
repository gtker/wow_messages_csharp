using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class SendCalendarHoliday {
    public required uint HolidayId { get; set; }
    public required uint Region { get; set; }
    public required uint Looping { get; set; }
    public required uint Priority { get; set; }
    public required uint CalendarFilterType { get; set; }
    public const int HolidayDaysLength = 26;
    public required uint[] HolidayDays { get; set; }
    public const int DurationsLength = 10;
    public required uint[] Durations { get; set; }
    public const int FlagsLength = 10;
    public required uint[] Flags { get; set; }
    public required string TextureFileName { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(HolidayId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Region, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Looping, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Priority, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(CalendarFilterType, cancellationToken).ConfigureAwait(false);

        foreach (var v in HolidayDays) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in Durations) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        foreach (var v in Flags) {
            await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);
        }

        await w.WriteCString(TextureFileName, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<SendCalendarHoliday> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var holidayId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var region = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var looping = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var priority = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var calendarFilterType = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var holidayDays = new uint[HolidayDaysLength];
        for (var i = 0; i < HolidayDaysLength; ++i) {
            holidayDays[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        var durations = new uint[DurationsLength];
        for (var i = 0; i < DurationsLength; ++i) {
            durations[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        var flags = new uint[FlagsLength];
        for (var i = 0; i < FlagsLength; ++i) {
            flags[i] = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        }

        var textureFileName = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new SendCalendarHoliday {
            HolidayId = holidayId,
            Region = region,
            Looping = looping,
            Priority = priority,
            CalendarFilterType = calendarFilterType,
            HolidayDays = holidayDays,
            Durations = durations,
            Flags = flags,
            TextureFileName = textureFileName,
        };
    }

    internal int Size() {
        var size = 0;

        // holiday_id: Generator.Generated.DataTypeInteger
        size += 4;

        // region: Generator.Generated.DataTypeInteger
        size += 4;

        // looping: Generator.Generated.DataTypeInteger
        size += 4;

        // priority: Generator.Generated.DataTypeInteger
        size += 4;

        // calendar_filter_type: Generator.Generated.DataTypeInteger
        size += 4;

        // holiday_days: Generator.Generated.DataTypeArray
        size += HolidayDays.Sum(e => 4);

        // durations: Generator.Generated.DataTypeArray
        size += Durations.Sum(e => 4);

        // flags: Generator.Generated.DataTypeArray
        size += Flags.Sum(e => 4);

        // texture_file_name: Generator.Generated.DataTypeCstring
        size += TextureFileName.Length + 1;

        return size;
    }

}

