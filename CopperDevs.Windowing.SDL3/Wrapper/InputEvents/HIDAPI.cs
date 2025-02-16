using CopperDevs.Windowing.SDL3.Data;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
namespace CopperDevs.Windowing.SDL3;

public static unsafe partial class SDL
{
    public static void hid_ble_scan() => SDL_hid_ble_scan();
    public static void hid_close() => SDL_hid_close();
    public static void hid_device_change_count() => SDL_hid_device_change_count();
    public static void hid_enumerate() => SDL_hid_enumerate();
    public static void hid_exit() => SDL_hid_exit();
    public static void hid_free_enumeration() => SDL_hid_free_enumeration();
    public static void hid_get_device_info() => SDL_hid_get_device_info();
    public static void hid_get_feature_report() => SDL_hid_get_feature_report();
    public static void hid_get_indexed_string() => SDL_hid_get_indexed_string();
    public static void hid_get_input_report() => SDL_hid_get_input_report();
    public static void hid_get_manufacturer_string() => SDL_hid_get_manufacturer_string();
    public static void hid_get_product_string() => SDL_hid_get_product_string();
    public static void hid_get_report_descriptor() => SDL_hid_get_report_descriptor();
    public static void hid_get_serial_number_string() => SDL_hid_get_serial_number_string();
    public static void hid_init() => SDL_hid_init();
    public static void hid_open() => SDL_hid_open();
    public static void hid_open_path() => SDL_hid_open_path();
    public static void hid_read() => SDL_hid_read();
    public static void hid_read_timeout() => SDL_hid_read_timeout();
    public static void hid_send_feature_report() => SDL_hid_send_feature_report();
    public static void hid_set_nonblocking() => SDL_hid_set_nonblocking();
    public static void hid_write() => SDL_hid_write();
}