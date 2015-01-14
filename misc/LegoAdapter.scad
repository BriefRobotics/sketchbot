$fn = 100;
infinitesimal = 0.1;

module knob_adapter(knob_height, knob_radius, knob_taper, knob_bevel_height, knob_bevel_radius, adapter_thickness) {
    height = knob_height + knob_bevel_height + adapter_thickness;
    translate([0, 0, -(height - infinitesimal)]) difference() {
        translate([0, 0, infinitesimal]) cylinder(h = height, r = knob_radius + knob_taper + adapter_thickness);
        union() {
            translate([0, 0, knob_height - infinitesimal]) cylinder(h = knob_bevel_height, r1 = knob_radius, r2 = knob_bevel_radius);
            cylinder(h = knob_height, r1 = knob_radius + knob_taper, r2 = knob_radius);
        }
    }
}

module peg_hole() {
    hole_radius = 2.3;
    cylinder(h = 20, r = hole_radius);
    cylinder(h = 1, r = hole_radius + 0.5);
}

module lego_adapter() {
    hole_offset = 8;
    difference() {
        cylinder(h = 7.5, r = 12);
        union() {
            translate([0, hole_offset, -infinitesimal]) peg_hole();
            translate([0, -hole_offset, -infinitesimal]) peg_hole();
            translate([hole_offset, 0, -infinitesimal]) peg_hole();
            translate([-hole_offset, 0, -infinitesimal]) peg_hole();
        }
    }
}

knob_adapter(9, 14, 0.1, 3.5, 11, 2);
translate([0, 0, 0]) lego_adapter();
