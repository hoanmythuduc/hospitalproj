// import mockData from '../../../mock/db.json';
// import DynamicTable from '../../../components/shared/DynamicTable';
// import ModuleWrapper from '../../../components/shared/ModuleWrapper';

// export default async function ModulePage({ params }) {
//   const moduleName = (await params).module; 
//   let schemaPath = null; 
//   mockData.menuGroups.forEach((group) => {
//     const foundMenu = group.menus.find((menu) => menu.path === `/${moduleName}`);
//     console.log(moduleName);
//     if (foundMenu) {
//       schemaPath = foundMenu.schemaPath;
//     }
//   });
//   const subTabMapping = {
//     'custom-fields': '/api/schema/custom-fields',
//     'form-actions': '/api/schema/form-actions',
//     'user-accounts': '/api/schema/users',
//     'user-groups': '/api/schema/groups'
//   };

//   console.log(`Module name: ${moduleName}`);

//   if (!schemaPath && subTabMapping[moduleName]) {
//     schemaPath = subTabMapping[moduleName];
//   }
//   const currentSchema = schemaPath ? mockData.schemas[schemaPath] : null;

//   if (!currentSchema) {
//     return (
//       <div className="flex flex-col items-center justify-center h-full text-gray-500 gap-3">
//         <div className="text-xl">This feature is not configured or you do not have permission to access it.</div>
//         <div className="text-sm bg-gray-100 px-4 py-2 rounded">
//           {/*<b>Debug URL đang tìm:</b> /{moduleName}*/}
//         </div>
//       </div>
//     );
//   }

//     console.log(`Current schema: ${currentSchema}`);

//   return (
//     <div className="w-full">
//       <DynamicTable schema={currentSchema} />
//     </div>
//   );
// }

import ModuleWrapper from '../../../components/shared/ModuleWrapper';

export default async function ModulePage({ params }) {
  const resolvedParams = await params;
  const moduleSlug = resolvedParams.module; 

  return (
    <div className="w-full h-full">
      <ModuleWrapper moduleSlug={moduleSlug} />
    </div>
  );
}