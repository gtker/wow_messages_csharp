using Generator.Extensions;
using Generator.Generated;

namespace Generator;

public static class Sanitizer
{
    private static readonly Dictionary<string, string> ReplacementNames = new()
    {
        { "class", "class_type" },
        { "string", "string_value" },
        { "event", "event_value" },
        { "float", "float_value" },
        { "new", "new_value" }
    };

    private static string ReplaceName(string arg, Container? c = null)
    {
        if (c != null)
        {
            if (c.Name == arg.ToMemberName())
            {
                arg += "_value";
            }
        }

        return ReplacementNames.GetValueOrDefault(arg, arg);
    }

    public static void SanitizeModel(IntermediateRepresentationSchema schema)
    {
        foreach (var e in schema.Login.Messages)
        {
            SanitizeContainer(e);
        }

        foreach (var e in schema.Login.Structs)
        {
            SanitizeContainer(e);
        }

        foreach (var e in schema.World.Messages)
        {
            SanitizeContainer(e);
        }

        foreach (var e in schema.World.Structs)
        {
            SanitizeContainer(e);
        }

        SanitizeUpdateMask(schema.VanillaUpdateMask);
        SanitizeUpdateMask(schema.TbcUpdateMask);
        SanitizeUpdateMask(schema.WrathUpdateMask);
    }

    private static void SanitizeUpdateMask(IList<UpdateMask> updateMasks)
    {
        foreach (var updateMask in updateMasks)
        {
            updateMask.Name = ReplaceName(updateMask.Name);

            switch (updateMask.DataType)
            {
                case UpdateMaskDataTypeArrayOfStruct e:
                    e.Content.VariableName = ReplaceName(e.Content.VariableName);

                    foreach (var members in e.Content.UpdateMaskStruct.Members)
                    {
                        foreach (var member in members)
                        {
                            member.Member.Name = ReplaceName(member.Member.Name);
                        }
                    }

                    break;
                case UpdateMaskDataTypeBytes b:
                    b.Content.First.Name = ReplaceName(b.Content.First.Name);

                    b.Content.Second.Name = ReplaceName(b.Content.Second.Name);

                    b.Content.Third.Name = ReplaceName(b.Content.Third.Name);

                    b.Content.Fourth.Name = ReplaceName(b.Content.Fourth.Name);

                    break;
                case UpdateMaskDataTypeTwoShort s:
                    s.Content.First.Name = ReplaceName(s.Content.First.Name);

                    s.Content.Second.Name = ReplaceName(s.Content.Second.Name);

                    break;
                case UpdateMaskDataTypeGuidArrayUsingEnum a:
                    a.Content.VariableName = ReplaceName(a.Content.VariableName);

                    break;
                case UpdateMaskDataTypeGuid:
                    break;
                case UpdateMaskDataTypeInt:
                    break;
                case UpdateMaskDataTypeFloat:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private static void SanitizeContainer(Container e)
    {
        foreach (var m in e.AllMembers())
        {
            switch (m)
            {
                case StructMemberDefinition d:
                    if (d.StructMemberContent.UsedAsSizeIn != null)
                    {
                        d.StructMemberContent.UsedAsSizeIn = ReplaceName(d.StructMemberContent.UsedAsSizeIn, e);
                    }

                    d.StructMemberContent.Name = ReplaceName(d.StructMemberContent.Name, e);
                    break;
                case StructMemberIfStatement statement:
                    statement.StructMemberContent.VariableName =
                        ReplaceName(statement.StructMemberContent.VariableName, e);

                    foreach (var elseif in statement.StructMemberContent.ElseIfStatements)
                    {
                        elseif.VariableName = ReplaceName(elseif.VariableName, e);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(m));
            }
        }

        foreach (var po in e.AllPreparedObjects())
        {
            po.Name = ReplaceName(po.Name, e);
        }
    }
}