#include <pb_decode.h>

#define TEST(x) if (!(x)) { \
    printf("Test " #x " failed (in field %d).\n", field->tag); \
    return false; \
    }

/*static*/ bool read_varint(pb_istream_t *stream, const pb_field_t *field, void **arg)
{
	uint64_t value;
	if (!pb_decode_varint(stream, &value))
		return false;

	TEST((int64_t)value == (long)*arg);
	return true;
}

/*static*/ bool read_svarint(pb_istream_t *stream, const pb_field_t *field, void **arg)
{
	int64_t value;
	if (!pb_decode_svarint(stream, &value))
		return false;

	TEST(value == (long)*arg);
	return true;
}

/*static*/ bool read_fixed32(pb_istream_t *stream, const pb_field_t *field, void **arg)
{
	uint32_t value;
	if (!pb_decode_fixed32(stream, &value))
		return false;

	TEST(value == *(uint32_t*)*arg);
	return true;
}

/*static*/ bool read_fixed64(pb_istream_t *stream, const pb_field_t *field, void **arg)
{
	uint64_t value;
	if (!pb_decode_fixed64(stream, &value))
		return false;

	TEST(value == *(uint64_t*)*arg);
	return true;
}

/*static*/ bool read_string(pb_istream_t *stream, const pb_field_t *field, void **arg)
{
	uint8_t buf[16] = { 0 };
	size_t len = stream->bytes_left;

	if (len > sizeof(buf) - 1 || !pb_read(stream, buf, len))
		return false;

	TEST(strcmp((char*)buf, *arg) == 0);
	return true;
}

//static bool read_submsg(pb_istream_t *stream, const pb_field_t *field, void **arg)
//{
//	SubMessage submsg = { "" };
//
//	if (!pb_decode(stream, SubMessage_fields, &submsg))
//		return false;
//
//	TEST(memcmp(&submsg, *arg, sizeof(submsg)));
//	return true;
//}
//
//static bool read_emptymsg(pb_istream_t *stream, const pb_field_t *field, void **arg)
//{
//	EmptyMessage emptymsg = { 0 };
//	return pb_decode(stream, EmptyMessage_fields, &emptymsg);
//}

/*static*/ bool read_repeated_varint(pb_istream_t *stream, const pb_field_t *field, void **arg)
{
	int32_t** expected = (int32_t**)arg;
	uint64_t value;
	if (!pb_decode_varint(stream, &value))
		return false;

	TEST(*(*expected)++ == value);
	return true;
}

/*static*/ bool read_repeated_svarint(pb_istream_t *stream, const pb_field_t *field, void **arg)
{
	int32_t** expected = (int32_t**)arg;
	int64_t value;
	if (!pb_decode_svarint(stream, &value))
		return false;

	TEST(*(*expected)++ == value);
	return true;
}

/*static*/ bool read_repeated_fixed32(pb_istream_t *stream, const pb_field_t *field, void **arg)
{
	uint32_t** expected = (uint32_t**)arg;
	uint32_t value;
	if (!pb_decode_fixed32(stream, &value))
		return false;

	TEST(*(*expected)++ == value);
	return true;
}

/*static*/ bool read_repeated_fixed64(pb_istream_t *stream, const pb_field_t *field, void **arg)
{
	uint64_t** expected = (uint64_t**)arg;
	uint64_t value;
	if (!pb_decode_fixed64(stream, &value))
		return false;

	TEST(*(*expected)++ == value);
	return true;
}

/*static*/ bool read_repeated_string(pb_istream_t *stream, const pb_field_t *field, void **arg)
{
	uint8_t*** expected = (uint8_t***)arg;
	uint8_t buf[16] = { 0 };
	size_t len = stream->bytes_left;

	if (len > sizeof(buf) - 1 || !pb_read(stream, buf, len))
		return false;

	TEST(strcmp((char*)*(*expected)++, (char*)buf) == 0);
	return true;
}

/*static bool read_repeated_submsg(pb_istream_t *stream, const pb_field_t *field, void **arg)
{
	SubMessage** expected = (SubMessage**)arg;
	SubMessage decoded = { "" };
	if (!pb_decode(stream, SubMessage_fields, &decoded))
		return false;

	TEST(memcmp((*expected)++, &decoded, sizeof(decoded)) == 0);
	return true;
}*/

/*static bool read_limits(pb_istream_t *stream, const pb_field_t *field, void **arg)
{
	Limits decoded = { 0 };
	if (!pb_decode(stream, Limits_fields, &decoded))
		return false;

	TEST(decoded.int32_min == INT32_MIN);
	TEST(decoded.int32_max == INT32_MAX);
	TEST(decoded.uint32_min == 0);
	TEST(decoded.uint32_max == UINT32_MAX);
	TEST(decoded.int64_min == INT64_MIN);
	TEST(decoded.int64_max == INT64_MAX);
	TEST(decoded.uint64_min == 0);
	TEST(decoded.uint64_max == UINT64_MAX);
	TEST(decoded.enum_min == HugeEnum_Negative);
	TEST(decoded.enum_max == HugeEnum_Positive);

	return true;
}*/