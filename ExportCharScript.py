import bpy
import time
import os


print("Hello")

def save_selected(char:str, index:int):
    bpy.ops.object.select_all(action='DESELECT')
    ##obj = bpy.data.objects['ToExport']
    obj = bpy.data.objects[0]
    obj.select_set(True)
    bpy.context.view_layer.objects.active = obj
    # Change object and material name to char value
 
    
    if bpy.context.object and bpy.context.object.type == 'FONT':
        text_obj = bpy.context.object
        
        text_obj.data.body = char
        text_obj.name = char
        text_obj.data.name = char
        for slot in text_obj.material_slots:
            slot.name = char
        
        bpy.context.view_layer.update()
        
        name= f"{char}"
        if index<=26:
            name = f"C_{char}"
        if index<=52:
            name = f"C_M_{char}"        
        else:
            name = f"C_{index}"
            
        print(f"{name}")
        
        blend_file_path = bpy.data.filepath
        directory = os.path.dirname(blend_file_path)
        target_file = os.path.join(directory, f"{name}.obj")
        print(f"Exported {obj.name} to {target_file}")
        
    
        #bpy.ops.export_scene.obj(filepath=target_file, use_selection=True)
        bpy.ops.wm.obj_export(filepath=target_file, export_selected_objects=True, export_materials=False)
    
        
    else:
        print("No active text object selected.")


"""
bpy.ops.wm.obj_export(
    filepath="filename.obj",
    check_existing=True,
    filter_blender=False,
    filter_backup=False,
    filter_image=False,
    filter_movie=False,
    filter_python=False,
    filter_font=False,
    filter_sound=False,
    filter_text=False,
    filter_archive=False,
    filter_btx=False,
    filter_collada=False,
    filter_alembic=False,
    filter_usd=False,
    filter_obj=False,
    filter_volume=False,
    filter_folder=True,
    filter_blenlib=False,
    filemode=8,
    display_type='DEFAULT',
    sort_method='DEFAULT',
    export_animation=False,
    start_frame=-2147483648,
    end_frame=2147483647,
    forward_axis='NEGATIVE_Z',
    up_axis='Y',
    global_scale=1.0,
    apply_modifiers=True,
    export_eval_mode='DAG_EVAL_VIEWPORT',
    export_selected_objects=False,
    export_uv=True,
    export_normals=True,
    export_colors=False,
    export_materials=True,
    export_pbr_extensions=False,
    path_mode='AUTO',
    export_triangulated_mesh=False,
    export_curves_as_nurbs=False,
    export_object_groups=False,
    export_material_groups=False,
    export_vertex_groups=False,
    export_smooth_groups=False,
    smooth_group_bitflags=False,
    filter_glob='*.obj;*.mtl'
)
"""

characters = "abc"

characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;':,.<>?/\\"

index:int=0 

int_length = len(characters)
while index < int_length:
    save_selected(characters[index], index)
    time.sleep(0.1)
    index += 1

