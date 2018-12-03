#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>
#include <string.h>
#include <pb_encode.h>

#ifdef PB_ENABLE_MALLOC
#include <stdlib.h>
#endif

/*static*/ bool write_varint(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
{
	return pb_encode_tag_for_field(stream, field) &&
		pb_encode_varint(stream, (long)*arg);
}

/*static*/ bool write_svarint(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
{
	return pb_encode_tag_for_field(stream, field) &&
		pb_encode_svarint(stream, (long)*arg);
}

/*static*/ bool write_fixed32(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
{
	return pb_encode_tag_for_field(stream, field) &&
		pb_encode_fixed32(stream, *arg);
}

/*static*/ bool write_fixed64(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
{
	return pb_encode_tag_for_field(stream, field) &&
		pb_encode_fixed64(stream, *arg);
}

/*static*/ bool write_string(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
{
	return pb_encode_tag_for_field(stream, field) &&
		pb_encode_string(stream, *arg, strlen(*arg));
}

//static bool write_submsg(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
//{
//
//	return pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, SubMessage_fields, *arg);
//}
//
//static bool write_emptymsg(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
//{
//	EmptyMessage emptymsg = { 0 };
//	return pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, EmptyMessage_fields, &emptymsg);
//}

/*static*/ bool write_repeated_varint(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
{
	return pb_encode_tag_for_field(stream, field) &&
		pb_encode_varint(stream, 0) &&
		pb_encode_tag_for_field(stream, field) &&
		pb_encode_varint(stream, 0) &&
		pb_encode_tag_for_field(stream, field) &&
		pb_encode_varint(stream, 0) &&
		pb_encode_tag_for_field(stream, field) &&
		pb_encode_varint(stream, 0) &&
		pb_encode_tag_for_field(stream, field) &&
		pb_encode_varint(stream, (long)*arg);
}

/*static*/ bool write_repeated_svarint(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
{
	return pb_encode_tag_for_field(stream, field) &&
		pb_encode_svarint(stream, 0) &&
		pb_encode_tag_for_field(stream, field) &&
		pb_encode_svarint(stream, 0) &&
		pb_encode_tag_for_field(stream, field) &&
		pb_encode_svarint(stream, 0) &&
		pb_encode_tag_for_field(stream, field) &&
		pb_encode_svarint(stream, 0) &&
		pb_encode_tag_for_field(stream, field) &&
		pb_encode_svarint(stream, (long)*arg);
}

/*static*/ bool write_repeated_fixed32(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
{
	uint32_t dummy = 0;

	/* Make it a packed field */
	return pb_encode_tag(stream, PB_WT_STRING, field->tag) &&
		pb_encode_varint(stream, 5 * 4) && /* Number of bytes */
		pb_encode_fixed32(stream, &dummy) &&
		pb_encode_fixed32(stream, &dummy) &&
		pb_encode_fixed32(stream, &dummy) &&
		pb_encode_fixed32(stream, &dummy) &&
		pb_encode_fixed32(stream, *arg);
}

/*static*/ bool write_repeated_fixed64(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
{
	uint64_t dummy = 0;

	/* Make it a packed field */
	return pb_encode_tag(stream, PB_WT_STRING, field->tag) &&
		pb_encode_varint(stream, 5 * 8) && /* Number of bytes */
		pb_encode_fixed64(stream, &dummy) &&
		pb_encode_fixed64(stream, &dummy) &&
		pb_encode_fixed64(stream, &dummy) &&
		pb_encode_fixed64(stream, &dummy) &&
		pb_encode_fixed64(stream, *arg);
}

/*static*/ bool write_repeated_string(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
{
	return pb_encode_tag_for_field(stream, field) &&
		pb_encode_string(stream, 0, 0) &&
		pb_encode_tag_for_field(stream, field) &&
		pb_encode_string(stream, 0, 0) &&
		pb_encode_tag_for_field(stream, field) &&
		pb_encode_string(stream, 0, 0) &&
		pb_encode_tag_for_field(stream, field) &&
		pb_encode_string(stream, 0, 0) &&
		pb_encode_tag_for_field(stream, field) &&
		pb_encode_string(stream, *arg, strlen(*arg));
}

//static bool write_repeated_submsg(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
//{
//	SubMessage dummy = { "" };
//
//	return pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, SubMessage_fields, &dummy) &&
//		pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, SubMessage_fields, &dummy) &&
//		pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, SubMessage_fields, &dummy) &&
//		pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, SubMessage_fields, &dummy) &&
//		pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, SubMessage_fields, *arg);
//}
//
//static bool write_limits(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
//{
//	Limits limits = { 0 };
//	limits.int32_min = INT32_MIN;
//	limits.int32_max = INT32_MAX;
//	limits.uint32_min = 0;
//	limits.uint32_max = UINT32_MAX;
//	limits.int64_min = INT64_MIN;
//	limits.int64_max = INT64_MAX;
//	limits.uint64_min = 0;
//	limits.uint64_max = UINT64_MAX;
//	limits.enum_min = HugeEnum_Negative;
//	limits.enum_max = HugeEnum_Positive;
//
//	return pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, Limits_fields, &limits);
//}
//
//static bool write_repeated_emptymsg(pb_ostream_t *stream, const pb_field_t *field, void * const *arg)
//{
//	EmptyMessage emptymsg = { 0 };
//	return pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, EmptyMessage_fields, &emptymsg) &&
//		pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, EmptyMessage_fields, &emptymsg) &&
//		pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, EmptyMessage_fields, &emptymsg) &&
//		pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, EmptyMessage_fields, &emptymsg) &&
//		pb_encode_tag_for_field(stream, field) &&
//		pb_encode_submessage(stream, EmptyMessage_fields, &emptymsg);
//}