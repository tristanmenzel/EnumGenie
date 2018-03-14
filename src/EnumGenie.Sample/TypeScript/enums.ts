export const enum CustomValues {
    First = 2,
    Second = 4,
    Third = 100
}
const CustomValuesDesc: any = {
  [CustomValues.First]: `First`,
  [CustomValues.Second]: `Second`,
  [CustomValues.Third]: `Third`,
};
export const customValuesDescription = (value: CustomValues): string => CustomValuesDesc[value];
export interface CustomValuesDescriptor { value: CustomValues; name: string; description: string; }
export const allCustomValues: CustomValuesDescriptor[] = [
 CustomValues.First,
 CustomValues.Second,
 CustomValues.Third
].map(value => ({value, name: CustomValues[value], description: CustomValuesDesc[value]}));
export const getCustomValuesDescriptor = (value: CustomValues): CustomValuesDescriptor => 
 allCustomValues.filter(d => d.value === value)[0];
export const enum Descriptions {
    First = 0,
    Second = 1,
    Third = 2
}
const DescriptionsDesc: any = {
  [Descriptions.First]: `Number 1`,
  [Descriptions.Second]: `Number 2`,
  [Descriptions.Third]: `Number 3`,
};
export const descriptionsDescription = (value: Descriptions): string => DescriptionsDesc[value];
export interface DescriptionsDescriptor { value: Descriptions; name: string; description: string; }
export const allDescriptions: DescriptionsDescriptor[] = [
 Descriptions.First,
 Descriptions.Second,
 Descriptions.Third
].map(value => ({value, name: Descriptions[value], description: DescriptionsDesc[value]}));
export const getDescriptionsDescriptor = (value: Descriptions): DescriptionsDescriptor => 
 allDescriptions.filter(d => d.value === value)[0];
export const enum Flags {
    None = 0,
    First = 1,
    Second = 2,
    Third = 4
}
const FlagsDesc: any = {
  [Flags.None]: `None`,
  [Flags.First]: `First`,
  [Flags.Second]: `Second`,
  [Flags.Third]: `Third`,
};
export const flagsDescription = (value: Flags): string => FlagsDesc[value];
export interface FlagsDescriptor { value: Flags; name: string; description: string; }
export const allFlags: FlagsDescriptor[] = [
 Flags.First,
 Flags.Second,
 Flags.Third
].map(value => ({value, name: Flags[value], description: FlagsDesc[value]}));
export const getFlagsDescriptor = (value: Flags): FlagsDescriptor => 
 allFlags.filter(d => d.value === value)[0];
export const enum Renamed {
    First = 0,
    Second = 1,
    Third = 2
}
const RenamedDesc: any = {
  [Renamed.First]: `First`,
  [Renamed.Second]: `Second`,
  [Renamed.Third]: `Third`,
};
export const renamedDescription = (value: Renamed): string => RenamedDesc[value];
export interface RenamedDescriptor { value: Renamed; name: string; description: string; }
export const allRenamed: RenamedDescriptor[] = [
 Renamed.First,
 Renamed.Second,
 Renamed.Third
].map(value => ({value, name: Renamed[value], description: RenamedDesc[value]}));
export const getRenamedDescriptor = (value: Renamed): RenamedDescriptor => 
 allRenamed.filter(d => d.value === value)[0];
export const enum Standard {
    First = 0,
    Second = 1,
    Third = 2
}
const StandardDesc: any = {
  [Standard.First]: `First`,
  [Standard.Second]: `Second`,
  [Standard.Third]: `Third`,
};
export const standardDescription = (value: Standard): string => StandardDesc[value];
export interface StandardDescriptor { value: Standard; name: string; description: string; }
export const allStandard: StandardDescriptor[] = [
 Standard.First,
 Standard.Second,
 Standard.Third
].map(value => ({value, name: Standard[value], description: StandardDesc[value]}));
export const getStandardDescriptor = (value: Standard): StandardDescriptor => 
 allStandard.filter(d => d.value === value)[0];
