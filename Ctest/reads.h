#pragma once
#include <pb_decode.h>

bool read_varint(pb_istream_t *stream, const pb_field_t *field, void **arg);

bool read_svarint(pb_istream_t *stream, const pb_field_t *field, void **arg);

bool read_fixed32(pb_istream_t *stream, const pb_field_t *field, void **arg);

bool read_fixed64(pb_istream_t *stream, const pb_field_t *field, void **arg);

bool read_string(pb_istream_t *stream, const pb_field_t *field, void **arg);

// bool read_submsg(pb_istream_t *stream, const pb_field_t *field, void **arg);

// bool read_emptymsg(pb_istream_t *stream, const pb_field_t *field, void **arg);

bool read_repeated_varint(pb_istream_t *stream, const pb_field_t *field, void **arg);

bool read_repeated_svarint(pb_istream_t *stream, const pb_field_t *field, void **arg);

bool read_repeated_fixed32(pb_istream_t *stream, const pb_field_t *field, void **arg);

bool read_repeated_fixed64(pb_istream_t *stream, const pb_field_t *field, void **arg);

bool read_repeated_string(pb_istream_t *stream, const pb_field_t *field, void **arg);

//bool read_repeated_submsg(pb_istream_t *stream, const pb_field_t *field, void **arg);

// bool read_limits(pb_istream_t *stream, const pb_field_t *field, void **arg);