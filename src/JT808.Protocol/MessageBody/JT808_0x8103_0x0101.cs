﻿using System.Text.Json;

using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;

namespace JT808.Protocol.MessageBody
{
    /// <summary>
    /// CAN 总线通道 1 上传时间间隔(s)，0 表示不上传
    /// </summary>
    public class JT808_0x8103_0x0101 : JT808_0x8103_BodyBase, IJT808MessagePackFormatter<JT808_0x8103_0x0101>, IJT808Analyze
    {
        public override uint ParamId { get; set; } = 0x0101;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; }
        /// <summary>
        /// CAN 总线通道 1 上传时间间隔(s)，0 表示不上传
        /// </summary>
        public ushort ParamValue { get; set; }

        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8103_0x0101 jT808_0x8103_0x0101 = new JT808_0x8103_0x0101();
            jT808_0x8103_0x0101.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0101.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0101.ParamValue = reader.ReadUInt16();
            writer.WriteNumber($"[{ jT808_0x8103_0x0101.ParamId.ReadNumber()}]参数ID", jT808_0x8103_0x0101.ParamId);
            writer.WriteNumber($"[{jT808_0x8103_0x0101.ParamLength.ReadNumber()}]参数长度", jT808_0x8103_0x0101.ParamLength);
            writer.WriteNumber($"[{ jT808_0x8103_0x0101.ParamValue.ReadNumber()}]参数值[CAN总线通道1, 上传时间间隔(s)，0 表示不上传]", jT808_0x8103_0x0101.ParamValue);
        }

        public JT808_0x8103_0x0101 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8103_0x0101 jT808_0x8103_0x0101 = new JT808_0x8103_0x0101();
            jT808_0x8103_0x0101.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0101.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0101.ParamValue = reader.ReadUInt16();
            return jT808_0x8103_0x0101;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x8103_0x0101 value, IJT808Config config)
        {
            writer.WriteUInt32(value.ParamId);
            writer.WriteByte(value.ParamLength);
            writer.WriteUInt16(value.ParamValue);
        }
    }
}
