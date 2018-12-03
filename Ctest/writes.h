#pragma once
#include <pb_encode.h>

bool write_varint(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

bool write_svarint(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

bool write_fixed32(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

bool write_fixed64(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

bool write_string(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

//bool write_submsg(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

//bool write_emptymsg(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

bool write_repeated_varint(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

bool write_repeated_svarint(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

bool write_repeated_fixed32(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

bool write_repeated_fixed64(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

bool write_repeated_string(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

//bool write_repeated_submsg(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

//bool write_limits(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);

//bool write_repeated_emptymsg(pb_ostream_t *stream, const pb_field_t *field, void * const *arg);