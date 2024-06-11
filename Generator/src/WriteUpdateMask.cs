using Generator.Extensions;
using Generator.Generated;

namespace Generator;

public static class WriteUpdateMasks
{
    public static void WriteUpdateMask(IList<UpdateMask> updateMasks, string module, string path)
    {
        var s = new Writer();
        s.Wln($"namespace WowWorldMessages.{module};");

        s.OpenCurly("public partial class UpdateMask");

        foreach (var updateMask in updateMasks)
        {
            if (updateMask.DataType is UpdateMaskDataTypeArrayOfStruct or UpdateMaskDataTypeGuidArrayUsingEnum)
            {
                continue;
            }

            var objectType = updateMask.ObjectType.ToString().Replace("_", "");
            s.Body($"public void Set{objectType}{updateMask.Name.ToPascalCase()}({updateMask.DataType.CsArgument()})",
                s =>
                {
                    switch (updateMask.DataType)
                    {
                        case UpdateMaskDataTypeArrayOfStruct updateMaskDataTypeArrayOfStruct:
                            break;
                        case UpdateMaskDataTypeGuidArrayUsingEnum updateMaskDataTypeGuidArrayUsingEnum:
                            break;
                        case UpdateMaskDataTypeBytes b:
                            var first = b.Content.First;
                            var second = b.Content.Second;
                            var third = b.Content.Third;
                            var fourth = b.Content.Fourth;

                            var firstCast = b.Content.First.InnerType is ByteTypeInnerTypeDefiner ? "(byte)" : "";
                            var secondCast = b.Content.Second.InnerType is ByteTypeInnerTypeDefiner ? "(byte)" : "";
                            var thirdCast = b.Content.Third.InnerType is ByteTypeInnerTypeDefiner ? "(byte)" : "";
                            var fourthCast = b.Content.Fourth.InnerType is ByteTypeInnerTypeDefiner ? "(byte)" : "";

                            s.Wln(
                                $"UpdateMaskUtils.AddBytes(_values, {updateMask.Offset}, {firstCast}{first.Name.ToVariableName()}, {secondCast}{second.Name.ToVariableName()}, {thirdCast}{third.Name.ToVariableName()}, {fourthCast}{fourth.Name.ToVariableName()});");

                            break;
                        case UpdateMaskDataTypeTwoShort t:
                            s.Wln(
                                $"UpdateMaskUtils.AddTwoShort(_values, {updateMask.Offset}, {t.Content.First.Name.ToVariableName()}, {t.Content.Second.Name.ToVariableName()});");
                            break;
                        case UpdateMaskDataTypeFloat:
                            s.Wln($"UpdateMaskUtils.AddFloat(_values, {updateMask.Offset}, value);");
                            break;
                        case UpdateMaskDataTypeGuid:
                            s.Wln($"UpdateMaskUtils.AddGuid(_values, {updateMask.Offset}, value);");
                            break;
                        case UpdateMaskDataTypeInt:
                            s.Wln($"UpdateMaskUtils.AddUInt(_values, {updateMask.Offset}, value);");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                });
            s.Newline();
        }

        s.ClosingCurly(); // public partial class UpdateMask

        File.WriteAllText(path, s.ToString());
    }
}