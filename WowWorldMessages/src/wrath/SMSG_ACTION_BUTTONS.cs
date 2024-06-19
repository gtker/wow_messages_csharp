using WowSrp.Header;

namespace WowWorldMessages.Wrath;

using ActionBarBehaviorType = OneOf.OneOf<SMSG_ACTION_BUTTONS.ActionBarBehaviorInitial, SMSG_ACTION_BUTTONS.ActionBarBehaviorSet, ActionBarBehavior>;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_ACTION_BUTTONS: WrathServerMessage, IWorldMessage {
    public class ActionBarBehaviorInitial {
        public const int DataLength = 144;
        public required ActionButton[] Data { get; set; }
    }
    public class ActionBarBehaviorSet {
        public const int DataLength = 144;
        public required ActionButton[] Data { get; set; }
    }
    public required ActionBarBehaviorType Behavior { get; set; }
    internal ActionBarBehavior BehaviorValue => Behavior.Match(
        _ => Wrath.ActionBarBehavior.Initial,
        _ => Wrath.ActionBarBehavior.Set,
        v => v
    );

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteByte((byte)BehaviorValue, cancellationToken).ConfigureAwait(false);

        if (Behavior.Value is SMSG_ACTION_BUTTONS.ActionBarBehaviorInitial actionBarBehaviorInitial) {
            foreach (var v in actionBarBehaviorInitial.Data) {
                await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
            }

        }
        else if (Behavior.Value is SMSG_ACTION_BUTTONS.ActionBarBehaviorSet actionBarBehaviorSet) {
            foreach (var v in actionBarBehaviorSet.Data) {
                await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
            }

        }

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 297, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 297, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_ACTION_BUTTONS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        ActionBarBehaviorType behavior = (Wrath.ActionBarBehavior)await r.ReadByte(cancellationToken).ConfigureAwait(false);

        if (behavior.Value is Wrath.ActionBarBehavior.Initial) {
            var data = new ActionButton[ActionBarBehaviorInitial.DataLength];
            for (var i = 0; i < ActionBarBehaviorInitial.DataLength; ++i) {
                data[i] = await Wrath.ActionButton.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
            }

            behavior = new ActionBarBehaviorInitial {
                Data = data,
            };
        }
        else if (behavior.Value is Wrath.ActionBarBehavior.Set) {
            var data = new ActionButton[ActionBarBehaviorSet.DataLength];
            for (var i = 0; i < ActionBarBehaviorSet.DataLength; ++i) {
                data[i] = await Wrath.ActionButton.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false);
            }

            behavior = new ActionBarBehaviorSet {
                Data = data,
            };
        }

        return new SMSG_ACTION_BUTTONS {
            Behavior = behavior,
        };
    }

    internal int Size() {
        var size = 0;

        // behavior: Generator.Generated.DataTypeEnum
        size += 1;

        if (Behavior.Value is SMSG_ACTION_BUTTONS.ActionBarBehaviorInitial actionBarBehaviorInitial) {
            // data: Generator.Generated.DataTypeArray
            size += actionBarBehaviorInitial.Data.Sum(e => 4);

        }
        else if (Behavior.Value is SMSG_ACTION_BUTTONS.ActionBarBehaviorSet actionBarBehaviorSet) {
            // data: Generator.Generated.DataTypeArray
            size += actionBarBehaviorSet.Data.Sum(e => 4);

        }

        return size;
    }

}

